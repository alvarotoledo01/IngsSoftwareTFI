using SistemaMedico.Models;

namespace SistemaMedicoV3.Models
{
    public class EvolucionMedica
    {
        public Guid Id { get; set; }
        public string Informe { get; set; }
        public string NombreCompletoMedico { get; set; }
        public DateTime Fecha { get; set; }
        public List<RecetaDigital> Recetas { get; set; }
        public List<PedidosLaboratorio> Pedidos { get; set; }
        public EvolucionMedica(string informe, string nombreCompletoMedico)
        {
            Id = Guid.NewGuid();
            Informe = informe;
            NombreCompletoMedico = nombreCompletoMedico;
            Fecha = DateTime.Now;
        }

        public void CrearRecetaDigital(string enfermedad, string descripcionMedicamento, string codigoMedicamento, string nombreCompletoPaciente, string nroAfiliado, string obraSocial)
        {
            Recetas.Add(new RecetaDigital(nombreCompletoPaciente, nroAfiliado, obraSocial, descripcionMedicamento, codigoMedicamento, enfermedad));
        }

        public void AgregarPedidoLaboratorio(string plantilla)
        {
            Pedidos.Add(new PedidosLaboratorio(plantilla));
        }
    }
}
