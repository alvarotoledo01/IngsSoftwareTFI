namespace SistemaMedico.Models
{
    public class ApiResponse
    {
        List<Medicamento> ListaMedicamentos { get; set; }
        List<ObraSocial> ListaObraSociales { get; set; }
    }

    public class Medicamento
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Formato { get; set; }
    }

    public class ObraSocial
    {
        public string Codigo { get; set; }
        public string Denominacion { get; set; }
        public string Sigla { get; set; }
    }
}
