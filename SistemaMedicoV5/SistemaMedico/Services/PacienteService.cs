using SistemaMedicoV3.Models;
using SistemaMedicoV3.Repository;

namespace SistemaMedico.Services
{
    public class PacienteService
    {
        private readonly List<Paciente> _pacientes;

        public PacienteService(PacientesRepository repositorio)
        {
            _pacientes = repositorio.ObtenerPacientes();
        }

        public Paciente? BuscarPorDni(int dni)
        {
            return _pacientes.FirstOrDefault(p => p.DNI == dni);
        }

        public List<Paciente> BuscarPorNombre(string nombre)
        {
            return _pacientes.Where(p => p.NombreCompleto.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Paciente> GetPacientes()
        {
            return _pacientes;
        }

        public void AgregarPaciente(Paciente nuevoPaciente)
        {
            var existente = BuscarPorDni(nuevoPaciente.DNI);
            if (existente != null)
            {
                _pacientes.Remove(existente);
            }
            _pacientes.Add(nuevoPaciente);
        }

        public bool EliminarPaciente(int dni)
        {
            var paciente = BuscarPorDni(dni);
            if (paciente != null)
            {
                _pacientes.Remove(paciente);
                return true;
            }
            return false;
        }
    }
}

