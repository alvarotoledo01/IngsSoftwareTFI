using Microsoft.AspNetCore.Mvc;
using SistemaMedico.Services;
using SistemaMedicoV3.Models;
using SistemaMedicoV3.Repository;

namespace SistemaMedico.Controllers
{
    public class HomeController : Controller
    {
        private readonly PacienteService _pacienteService;

        // Constructor para inyectar el servicio PacienteService
        public HomeController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        // Acción Index que maneja la búsqueda de pacientes
        public IActionResult Index(string searchTerm)
        {
            List<Paciente> pacientes = new List<Paciente>(); // Inicializa la lista vacía

            if (!string.IsNullOrEmpty(searchTerm))  // Si hay un término de búsqueda
            {
                if (int.TryParse(searchTerm, out int dni)) // Si el término es un DNI válido
                {
                    var paciente = _pacienteService.BuscarPorDni(dni);
                    if (paciente != null)
                    {
                        pacientes.Add(paciente); // Agrega el paciente encontrado
                    }
                }
                else
                {
                    // Si no es un DNI, se puede intentar buscar por nombre
                    pacientes = _pacienteService.BuscarPorNombre(searchTerm); // Método para buscar por nombre
                }
            }
            else
            {
                // Si no hay término de búsqueda, se retornan todos los pacientes
                pacientes = _pacienteService.GetPacientes(); // Método que devuelve todos los pacientes
            }

            return View(pacientes); // Asegúrate de pasar una lista (vacía o con pacientes)
        }


    }
}

