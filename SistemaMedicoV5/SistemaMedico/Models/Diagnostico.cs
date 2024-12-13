namespace SistemaMedicoV3.Models
{
    public class Diagnostico
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Enfermedad { get; set; }
        public List<EvolucionMedica> Evoluciones { get; set; }
        public Diagnostico(string enfermedad)
        {
            Id = new Guid();
            Enfermedad = enfermedad;
            Evoluciones = new List<EvolucionMedica>();
            Fecha = DateTime.Now;
        }
        public void AgregarEvolucion(string informe, string nombreCompletoMedico)
        {
            Evoluciones.Add(new EvolucionMedica(informe, nombreCompletoMedico));
        }

        public void AgregarPedidoLaboratorio(Guid idEvolucion, string PlantillaPedido)
        {
            var evolucion = Evoluciones.FirstOrDefault(d => d.Id == idEvolucion);
            if (evolucion == null)
            {
                throw new Exception($"Evolucion con ID {idEvolucion} no encontrada.");
            }
            evolucion.AgregarPedidoLaboratorio(PlantillaPedido);
        }

        public void CrearRecetaDigital(Guid idEvolucion,string enfermedad, string descripcionMedicamento, string codigoMedicamento, string nombreCompletoPaciente, string nroAfiliado, string obraSocial)
        {
            var evolucion = Evoluciones.FirstOrDefault(d => d.Id == idEvolucion);
            if (evolucion == null)
            {
                throw new Exception($"Evolucion con ID {idEvolucion} no encontrada.");
            }


            evolucion.CrearRecetaDigital(enfermedad, descripcionMedicamento, codigoMedicamento, nombreCompletoPaciente, nroAfiliado, obraSocial);
        }
    }
}
