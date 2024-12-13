using Newtonsoft.Json;
using SistemaMedico.Models;
namespace SistemaMedico.Services
{
    public class ApiResponseService
    {
        private readonly HttpClient _httpClient;

        public ApiResponseService()
        {
            _httpClient = new HttpClient();
        }


        public async Task<Medicamento?> ValidarMedicamento(string nombreoCodigoMedicamento)
        {
            //con esto obtengo el medicamento a partir del codigo
            var medicamentoPorCodigo = await BuscarMedicamentoPorCodigo(nombreoCodigoMedicamento);
            if (medicamentoPorCodigo != null)
                return medicamentoPorCodigo;


            int pagina = 1;
            while (true)
            {
                var medicamentos = await ObtenerMedicamentos(pagina);

                if (medicamentos == null || medicamentos.Count == 0) return null;

                var medicamentoValido = medicamentos.FirstOrDefault(o =>
                o.Codigo.Equals(nombreoCodigoMedicamento, StringComparison.OrdinalIgnoreCase) ||
                o.Descripcion.Equals(nombreoCodigoMedicamento, StringComparison.OrdinalIgnoreCase));

                if (medicamentoValido != null) return medicamentoValido;

                pagina++; 
            }
        }

        public async Task<List<Medicamento>?> ObtenerMedicamentos(int pagina)
        {
            List<Medicamento> lista = new List<Medicamento>();
            string url = $"https://istp1service.azurewebsites.net/api/servicio-salud/medicamentos/todos?pagina={pagina}&limite=1000";
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Medicamento>>(jsonRespuesta) ?? new List<Medicamento>();
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud: Código de estado {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener medicamentos en la página {pagina}: {ex.Message}");
            }
            return lista;
        }
        public async Task<List<Medicamento>?> BuscarMedicamentoQueCoincidenConParteDescripcion(string descripcion)
        {
            List<Medicamento> lista = new List<Medicamento>();
            string url = $"https://istp1service.azurewebsites.net/api/servicio-salud/medicamentos?descripcion={descripcion}";
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Medicamento>>(jsonRespuesta) ?? new List<Medicamento>();
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud por descripción '{descripcion}': Código de estado {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar medicamentos por descripción '{descripcion}': {ex.Message}");
            }
            return lista;
        }
        public async Task<Medicamento?> BuscarMedicamentoPorCodigo(string codigo)
        {
            Medicamento? medicamento = null;
            string url = $"https://istp1service.azurewebsites.net/api/servicio-salud/medicamentos/{codigo}";
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    medicamento = JsonConvert.DeserializeObject<Medicamento>(jsonRespuesta);
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud por código '{codigo}': Código de estado {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar medicamento por código '{codigo}': {ex.Message}");
            }
            return medicamento;
        }

        public async Task<ObraSocial?> ValidarObraSocial(string nombreOCodigo)
        {
            var obraSocialPorCodigo = await ObtenerObraSocialPorCodigo(nombreOCodigo);
            if (obraSocialPorCodigo != null)
                return obraSocialPorCodigo;

            var obrasSociales = await ObtenerObrasSociales();
            if (obrasSociales == null || obrasSociales.Count == 0) return null;

            var obraSocialValida = obrasSociales.FirstOrDefault(o =>
                o.Codigo.Equals(nombreOCodigo, StringComparison.OrdinalIgnoreCase) ||
                o.Denominacion.Equals(nombreOCodigo, StringComparison.OrdinalIgnoreCase));

            if (obraSocialValida != null) return obraSocialValida;
            
            return null;
        }

        public async Task<List<ObraSocial>?> ObtenerObrasSociales()
        {
            List<ObraSocial> lista = new List<ObraSocial>();
            string url = "https://istp1service.azurewebsites.net/api/servicio-salud/obras-sociales";
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<ObraSocial>>(jsonRespuesta) ?? new List<ObraSocial>();
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud de obras sociales: Código de estado {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener obras sociales: {ex.Message}");
            }
            return lista;
        }
        public async Task<ObraSocial?> ObtenerObraSocialPorCodigo(string codigo)
        {
            ObraSocial? obraSocial = null;
            string url = $"https://istp1service.azurewebsites.net/api/servicio-salud/obras-sociales/{codigo}";
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    obraSocial = JsonConvert.DeserializeObject<ObraSocial>(jsonRespuesta);
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud de obra social por código '{codigo}': Código de estado {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener obra social por código '{codigo}': {ex.Message}");
            }
            return obraSocial;
        }


    }
}
