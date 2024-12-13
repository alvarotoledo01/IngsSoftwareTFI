using SistemaMedico.Controllers;
using SistemaMedico.Repository;
using SistemaMedico.Services;
using SistemaMedicoV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class EvolucionMedicaTests
    {
        [Fact]
        public void AgregarEvolucionExitoUsandoControladorClinica()
        {
            // Arrange
            var pacienteRepositorio = new PacientesRepository();
            var pacienteService = new PacienteService(pacienteRepositorio);
            var apiService = new ApiResponseService();
            var controlador = new ClinicaController(pacienteService, apiService);

            var medico = new Medico(20123456789, 12345678, "ABC12345", "Cardiología", new DateTime(1990, 6, 10), 123456789, "Juan Pérez", "Av. Siempre Viva 123", "Springfield", "Buenos Aires", "Argentina", "usuario1@example.com");

            var paciente = new Paciente(1, 12345, DateTime.Now, "email@test.com", 123456, "Juan", "OSDE", "123", "Calle", "Ciudad", "Provincia", "Pais");

            pacienteService.AgregarPaciente(paciente);

            // Act
            controlador.AgregarDiagnostico(12345, "Gripe");
            var diagnosticoId = paciente.HistoriaClinica.Diagnosticos[0].Id;
            controlador.AgregarEvolucion(12345, diagnosticoId, "Evolución positiva", medico.NombreCompleto);

            // Assert
            Assert.Single(paciente.HistoriaClinica.Diagnosticos[0].Evoluciones);
            Assert.Equal("Evolución positiva", paciente.HistoriaClinica.Diagnosticos[0].Evoluciones[0].Informe);
            Assert.Equal("Juan Pérez", paciente.HistoriaClinica.Diagnosticos[0].Evoluciones[0].NombreCompletoMedico);
        }
        [Fact]
        public void AgregarEvolucionDiagnosticoNoEncontradoExcepcion()
        {
            // Arrange
            var repositorio = new PacientesRepository();
            var pacienteService = new PacienteService(repositorio);
            var apiService = new ApiResponseService();
            var controlador = new ClinicaController(pacienteService, apiService);

            var medico = new Medico(20123456789, 12345678, "ABC12345", "Cardiología", new DateTime(1990, 6, 10), 123456789, "Juan Pérez", "Av. Siempre Viva 123", "Springfield", "Buenos Aires", "Argentina", "usuario1@example.com");

            var paciente = new Paciente(1, 12345, DateTime.Now, "email@test.com", 123456, "Juan", "OSDE", "123", "Calle", "Ciudad", "Provincia", "Pais");
            pacienteService.AgregarPaciente(paciente);

            var diagnosticoIdInexistente = Guid.NewGuid();

            // Act & Assert
            Assert.Throws<Exception>(() => controlador.AgregarEvolucion(12345, diagnosticoIdInexistente, "Evolución nueva", medico.NombreCompleto));
        }
        [Fact]
        public void AgregarEvolucionMultiplesEvoluciones()
        {
            // Arrange
            var repositorio = new PacientesRepository();
            var pacienteService = new PacienteService(repositorio);
            var apiService = new ApiResponseService();
            var controlador = new ClinicaController(pacienteService, apiService);

            var medico = new Medico(20123456789, 12345678, "ABC12345", "Cardiología", new DateTime(1990, 6, 10), 123456789, "Juan Pérez", "Av. Siempre Viva 123", "Springfield", "Buenos Aires", "Argentina", "usuario1@example.com");

            var paciente = new Paciente(1, 12345, DateTime.Now, "email@test.com", 123456, "Juan", "OSDE", "123", "Calle", "Ciudad", "Provincia", "Pais");
            paciente.AgregarDiagnostico("Diabetes");
            var diagnosticoId = paciente.HistoriaClinica.Diagnosticos[0].Id;

            pacienteService.AgregarPaciente(paciente);

            // Act
            controlador.AgregarEvolucion(12345, diagnosticoId, "Primera evolución", medico.NombreCompleto);
            controlador.AgregarEvolucion(12345, diagnosticoId, "Segunda evolución", medico.NombreCompleto);

            // Assert
            Assert.Equal(2, paciente.HistoriaClinica.Diagnosticos[0].Evoluciones.Count);
            Assert.Equal("Primera evolución", paciente.HistoriaClinica.Diagnosticos[0].Evoluciones[0].Informe);
            Assert.Equal("Segunda evolución", paciente.HistoriaClinica.Diagnosticos[0].Evoluciones[1].Informe);
            Assert.Equal("Juan Pérez", paciente.HistoriaClinica.Diagnosticos[0].Evoluciones[0].NombreCompletoMedico);
            Assert.Equal("Juan Pérez", paciente.HistoriaClinica.Diagnosticos[0].Evoluciones[1].NombreCompletoMedico);
        }

        [Fact]
        public void AgregarEvolucionPacienteNoEncontradoExcepcion()
        {
            // Arrange
            var repositorio = new PacientesRepository();
            var pacienteService = new PacienteService(repositorio);
            var apiService = new ApiResponseService();
            var controlador = new ClinicaController(pacienteService, apiService);

            var medico = new Medico(20123456789, 12345678, "ABC12345", "Cardiología", new DateTime(1990, 6, 10), 123456789, "Juan Pérez", "Av. Siempre Viva 123", "Springfield", "Buenos Aires", "Argentina", "usuario1@example.com");

            // Un paciente con este DNI no ha sido registrado
            var dniInexistente = 99999;
            var diagnosticoId = Guid.NewGuid();

            // Act & Assert
            Assert.Throws<Exception>(() => controlador.AgregarEvolucion(dniInexistente, diagnosticoId, "Evolución paciente no encontrado", medico.NombreCompleto));
        }

        [Fact]
        public void AgregarEvolucionSinInformeLanzarExcepcion()
        {
            // Arrange
            var repositorio = new PacientesRepository();
            var pacienteService = new PacienteService(repositorio);
            var apiService = new ApiResponseService();
            var controlador = new ClinicaController(pacienteService, apiService);

            var medico = new Medico(20123456789, 12345678, "ABC12345", "Cardiología", new DateTime(1990, 6, 10), 123456789, "Juan Pérez", "Av. Siempre Viva 123", "Springfield", "Buenos Aires", "Argentina", "usuario1@example.com");

            var paciente = new Paciente(1, 12345, DateTime.Now, "email@test.com", 123456, "Juan", "OSDE", "123", "Calle", "Ciudad", "Provincia", "Pais");
            paciente.AgregarDiagnostico("Faringitis");

            var diagnosticoId = paciente.HistoriaClinica.Diagnosticos[0].Id;

            pacienteService.AgregarPaciente(paciente);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => controlador.AgregarEvolucion(12345, diagnosticoId, "", medico.NombreCompleto));
            Assert.Throws<ArgumentException>(() => controlador.AgregarEvolucion(12345, diagnosticoId, null, medico.NombreCompleto));
        }
    }
}
