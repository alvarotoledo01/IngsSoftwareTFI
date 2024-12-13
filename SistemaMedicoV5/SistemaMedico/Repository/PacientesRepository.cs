using SistemaMedico.Repository;
using SistemaMedicoV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

public class PacientesRepository
{
    private List<Paciente> pacientes;
    public PacientesRepository()
    {
        // Inicializa la lista en el constructor.
        pacientes = new List<Paciente>
        {
            new Paciente(
                cuil: 20123456789,
                dni: 12345678,
                fechaNacimiento: new DateTime(1990, 6, 10),
                email: "usuario1@example.com",
                telefono: 123456789,
                nombreCompleto: "Juan Pérez",
                obraSocial: "Osde",
                nroAfiliado: "123456",
                direccion: "Av. Siempre Viva 123",
                localidad: "Springfield",
                provincia: "Buenos Aires",
                pais: "Argentina"
            ),
            new Paciente(
                cuil: 20876543210,
                dni: 87654321,
                fechaNacimiento: new DateTime(1985, 4, 25),
                email: "usuario2@example.com",
                telefono: 987654321,
                nombreCompleto: "María López",
                obraSocial: "Swiss Medical",
                nroAfiliado: "654321",
                direccion: "Calle Falsa 456",
                localidad: "Shelbyville",
                provincia: "Córdoba",
                pais: "Argentina"
            ),
            new Paciente(
        cuil: 20987654321,
        dni: 98765432,
        fechaNacimiento: new DateTime(1978, 12, 15),
        email: "usuario3@example.com",
        telefono: 1122334455,
        nombreCompleto: "Carlos Gómez",
        obraSocial: "Galeno",
        nroAfiliado: "789012",
        direccion: "Ruta 22 km 15",
        localidad: "Rosario",
        provincia: "Santa Fe",
        pais: "Argentina"
    ),
    new Paciente(
        cuil: 20112233445,
        dni: 11223344,
        fechaNacimiento: new DateTime(1995, 8, 30),
        email: "usuario4@example.com",
        telefono: 556677889,
        nombreCompleto: "Ana Martínez",
        obraSocial: "Osde",
        nroAfiliado: "345678",
        direccion: "Av. Central 789",
        localidad: "La Plata",
        provincia: "Buenos Aires",
        pais: "Argentina"
    ),
    new Paciente(
        cuil: 20990011223,
        dni: 99001122,
        fechaNacimiento: new DateTime(2000, 2, 14),
        email: "usuario5@example.com",
        telefono: 667788990,
        nombreCompleto: "Laura Fernández",
        obraSocial: "IOMA",
        nroAfiliado: "112233",
        direccion: "Calle 7 1234",
        localidad: "Tandil",
        provincia: "Buenos Aires",
        pais: "Argentina"
    )
        };

        var paciente1 = pacientes[0];
        paciente1.AgregarDiagnostico("Gripe");
        paciente1.AgregarDiagnostico("Covid");

        var diagnosticoGripe1 = paciente1.HistoriaClinica.Diagnosticos.FirstOrDefault(d => d.Enfermedad == "Gripe");
        diagnosticoGripe1?.AgregarEvolucion("Paciente con fiebre y tos", "Juan Pérez");

        var diagnosticoCovid1 = paciente1.HistoriaClinica.Diagnosticos.FirstOrDefault(d => d.Enfermedad == "Covid");
        diagnosticoCovid1?.AgregarEvolucion("pérdida de olfato", "Carlos Garcia");

        var diagnosticoCovid3 = paciente1.HistoriaClinica.Diagnosticos.FirstOrDefault(d => d.Enfermedad == "Covid");
        diagnosticoCovid1?.AgregarEvolucion("pérdida de gusto", "Carlos Garcia");

        var paciente2 = pacientes[1];
        paciente2.AgregarDiagnostico("Neumonia");
        paciente2.AgregarDiagnostico("Fiebre Amarilla");

        var diagnosticoGripe2 = paciente2.HistoriaClinica.Diagnosticos.FirstOrDefault(d => d.Enfermedad == "Neumonia");
        diagnosticoGripe2?.AgregarEvolucion("Paciente con tos", "Juan Pérez");

        var diagnosticoCovid2 = paciente2.HistoriaClinica.Diagnosticos.FirstOrDefault(d => d.Enfermedad == "Fiebre Amarilla");
        diagnosticoCovid2?.AgregarEvolucion("Paciente fiebre", "Carlos Garcia");
    }

    public List<Paciente> ObtenerPacientes()
    {
        return pacientes;
    }

}
