using SistemaMedico.Services;
using SistemaMedico.Models;
using SistemaMedicoV3.Models;
using Microsoft.AspNetCore.Mvc;
using SistemaMedico.Repository;

namespace SistemaMedico.Controllers
{
    public class ClinicaController : Controller
    {
        private PacienteService _service;
        private ApiResponseService _apiService;
        
        public ClinicaController(PacienteService pacienteService, ApiResponseService apiService)
        {
            _service = pacienteService;
            _apiService = apiService;
        }

        public void AgregarEvolucion(int dni, Guid idDiagnostico, string informe, string nombreCompletoMedico)
        {
            
            var paciente = _service.BuscarPorDni(dni);

            if (paciente == null)
            {
                throw new Exception($"Paciente con DNI {dni} no encontrado");
            }

            if (string.IsNullOrEmpty(informe))
            {
                throw new ArgumentException();
            }

            paciente.AgregarEvolucion(idDiagnostico, informe, nombreCompletoMedico);
        }

        public void AgregarDiagnostico(int dni, string enfermedad)
        {
            var paciente = _service.BuscarPorDni(dni);

            if (paciente == null)
            {
                throw new Exception($"Paciente con DNI {dni} no encontrado");
            }

            paciente.AgregarDiagnostico(enfermedad);
        }

        public Guid AgregarDiagnosticoConRetornoId(int dni, string enfermedad)
        {
            Guid id = new Guid();
            var paciente = _service.BuscarPorDni(dni);

            if (paciente == null)
            {
                throw new Exception($"Paciente con DNI {dni} no encontrado");
            }

            paciente.AgregarDiagnosticoConRetornoId(enfermedad);
            return id;
        }

        public void AgregarInformeConDiagnosticoNuevo(int dni, string enfermedad, string informe, string nombreCompletoMedico = "Carlos Garcia")
        {
            var id = AgregarDiagnosticoConRetornoId(dni, enfermedad);

            AgregarEvolucion(dni, id, informe, nombreCompletoMedico);
        }

        public void AgregarPedidoLaboratorio(int dni, Guid idDiagnostico, Guid idEvolucion, string PlantillaPedido)
        {
            var paciente = _service.BuscarPorDni(dni);

            if (paciente == null)
            {
                throw new Exception($"Paciente con DNI {dni} no encontrado");
            }

            paciente.AgregarPedidoLaboratorio(idDiagnostico, idEvolucion, PlantillaPedido);
        }

        public async Task CrearRecetaDigital(int dni, Guid idDiagnostico, Guid idEvolucion, string nombreMedicamento, string obraSocial )
        {
            var paciente = _service.BuscarPorDni(dni);

            if (paciente == null) throw new Exception($"Paciente con DNI {dni} no encontrado");

            var medicamentovalido = await _apiService.ValidarMedicamento(nombreMedicamento);

            if (medicamentovalido == null) throw new Exception("El medicamento ingresado no es válido.");

            var obraSocialValida = await _apiService.ValidarObraSocial(obraSocial);

            if (obraSocialValida == null) throw new Exception("La Obra Social ingresada no es válida.");

            paciente.CrearRecetaDigital(idDiagnostico, idEvolucion, medicamentovalido.Descripcion, medicamentovalido.Codigo, paciente.NombreCompleto, paciente.NroAfiliado, obraSocialValida.Denominacion);

        }
        [HttpGet]
        public IActionResult Evolucion(int dni)
        {
            var paciente = _service.BuscarPorDni(dni);
            if (paciente == null)
            {
                return NotFound($"Paciente con DNI {dni} no encontrado.");
            }

            return View("~/Views/Paciente/Evolucion.cshtml", paciente); // Carga la vista Evolucion.cshtml con el modelo del paciente
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarInforme(int dni, Guid? idDiagnosticoPrevio, string nuevoDiagnostico, string observacionesGenerales)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var paciente = _service.BuscarPorDni(dni);
                    if (paciente == null)
                    {
                        return Json(new { success = false, message = $"Paciente con DNI {dni} no encontrado." });
                    }

                    // Si se seleccionó un diagnóstico previo
                    if (idDiagnosticoPrevio.HasValue && idDiagnosticoPrevio != Guid.Empty)
                    {
                        AgregarEvolucion(dni, idDiagnosticoPrevio.Value, observacionesGenerales, "Carlos Garcia");
                    }
                    // Si no se seleccionó diagnóstico previo, agregar diagnóstico nuevo
                    else if (!string.IsNullOrEmpty(nuevoDiagnostico))
                    {
                        Guid idDiagnosticoNuevo = AgregarDiagnosticoConRetornoId(dni, nuevoDiagnostico);
                        AgregarEvolucion(dni, idDiagnosticoNuevo, observacionesGenerales, "Carlos Garcia");
                    }
                    else
                    {
                        return Json(new { success = false, message = "Debe seleccionar o ingresar un diagnóstico." });
                    }

                    return Json(new { success = true, message = "Informe guardado correctamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"Error al guardar el informe: {ex.Message}" });
                }
            }

            return Json(new { success = false, message = "Datos inválidos. Por favor, revise el formulario." });
        }


    }


} 
