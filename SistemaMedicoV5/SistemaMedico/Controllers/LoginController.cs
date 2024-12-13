using Microsoft.AspNetCore.Mvc;
using SistemaMedicoV3.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace SistemaMedicoV3.Controllers
{
    public class LoginController : Controller
    {
        private readonly AutenticarService _autenticarService;

        // Inyección de dependencia del servicio de autenticación
        public LoginController(AutenticarService autenticarService)
        {
            _autenticarService = autenticarService;
        }

        public IActionResult Login()
        {
            return View("~/Views/Home/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Por favor, ingresa ambos campos.";
                return View("~/Views/Home/Login.cshtml");
            }

            var medico = _autenticarService.IniciarSesion(email, password);
            if (medico != null)
            {
                // puedo serealizar todo el objeto medico
                //var medicoJson = JsonConvert.SerializeObject(medico);
                //HttpContext.Session.SetString("MedicoLogueado", medicoJson);
                // puedo serealizar solo los atributos que voy a usar pero luego debo deserealizar
                // Guardar el médico en la sesión
                HttpContext.Session.SetString("MedicoNombreCompleto", medico.NombreCompleto);
                HttpContext.Session.SetString("MedicoEmail", medico.Email);
                HttpContext.Session.SetInt32("MedicoDNI", medico.DNI);
                HttpContext.Session.SetString("MedicoMatriculaMedica", medico.MatriculaMedica);
                
                return View("~/Views/Home/Index.cshtml");
            }
            
            
            ViewBag.Error = "Email o contraseña incorrectos.";
            return View("~/Views/Home/Login.cshtml");
        }
    }
}

