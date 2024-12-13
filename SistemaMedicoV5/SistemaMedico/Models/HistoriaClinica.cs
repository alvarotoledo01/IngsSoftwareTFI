namespace SistemaMedicoV3.Models
{
    public class HistoriaClinica
    {
        public int DNI { get; private set; }
        public List<Diagnostico> Diagnosticos { get; set; }

        public HistoriaClinica(int dni)
        {
            DNI = dni;
            Diagnosticos = new List<Diagnostico>();
        }

        public Guid AgregarDiagnosticoConRetornoId(string enfermedad)
        {

            Diagnostico diagnostico = new Diagnostico(enfermedad);
            Diagnosticos.Add(diagnostico);
            
            return diagnostico.Id;
        }
        public void AgregarDiagnostico(string enfermedad)
        {
            Diagnostico diagnostico = new Diagnostico(enfermedad);
            Diagnosticos.Add(diagnostico);
        }

        public void AgregarEvolucion(Guid idDiagnostico, string informe ,string nombreCompletoMedico)
        {
            var diagnostico = Diagnosticos.FirstOrDefault(d => d.Id == idDiagnostico);
            if (diagnostico == null)
            {
                throw new Exception($"Diagnóstico con ID {idDiagnostico} no encontrado.");
            }

            diagnostico.AgregarEvolucion(informe, nombreCompletoMedico);
        }

        public void AgregarPedidoLaboratorio(Guid idDiagnostico, Guid idEvolucion, string PlantillaPedido)
        {
            var diagnostico = Diagnosticos.FirstOrDefault(d => d.Id == idDiagnostico);
            if (diagnostico == null)
            {
                throw new Exception($"Diagnóstico con ID {idDiagnostico} no encontrado.");
            }
            diagnostico.AgregarPedidoLaboratorio(idEvolucion, PlantillaPedido);
        }

        public void CrearRecetaDigital(Guid idDiagnostico, Guid idEvolucion, string descripcionMedicamento, string codigoMedicamento, string nombreCompletoPaciente, string nroAfiliado, string obraSocial)
        {
            var diagnostico = Diagnosticos.FirstOrDefault(d => d.Id == idDiagnostico);
            if (diagnostico == null)
                throw new Exception($"Diagnóstico con ID {idDiagnostico} no encontrado.");

            diagnostico.CrearRecetaDigital(idEvolucion, diagnostico.Enfermedad, descripcionMedicamento, codigoMedicamento, nombreCompletoPaciente, nroAfiliado, obraSocial);
        }
    }
}
