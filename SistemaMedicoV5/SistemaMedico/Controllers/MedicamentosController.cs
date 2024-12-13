using Microsoft.AspNetCore.Mvc;
using SistemaMedico.Services;

[ApiController]
[Route("api/medicamentos")]
public class MedicamentosController : ControllerBase
{
    private readonly ApiResponseService _apiService;

    public MedicamentosController(ApiResponseService apiService)
    {
        _apiService = apiService;
    }

    [HttpGet("sugerencias")]
    public async Task<IActionResult> ObtenerSugerencias([FromQuery] string descripcion)
    {
        if (string.IsNullOrWhiteSpace(descripcion))
            return Ok(new List<object>());

        Console.WriteLine($"Descripción recibida: {descripcion}");  // Agregar log para verificar

        var medicamentos = await _apiService.BuscarMedicamentoQueCoincidenConParteDescripcion(descripcion);

        if (medicamentos == null || !medicamentos.Any())
            return Ok(new List<object>());

        var resultado = medicamentos.Select(m => new
        {
            m.Codigo,
            m.Descripcion
        }).ToList();

        return Ok(resultado);
    }

}
