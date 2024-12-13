 namespace SistemaMedicoV3.Models
{
    public class RecetaDigital
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Fecha { get; private set; }
        public string NombreCompletoPaciente { get; private set; }
        public string NumeroAfiliado { get; private set; }
        public string ObraSocial { get; private set; }
        public string DescripcionMedicamento { get; private set; }
        public string CodigoMedicamento { get; private set; }
        public string Enfermedad { get; private set; }


        public RecetaDigital(string nombreCompletoPaciente, string numeroAfiliado, string obraSocial,
                             string descripcionMedicamento, string codigoMedicamento, string enfermedad)
        {
            Fecha = DateTime.Now;
            NombreCompletoPaciente = nombreCompletoPaciente;
            NumeroAfiliado = numeroAfiliado;
            ObraSocial = obraSocial;
            DescripcionMedicamento = descripcionMedicamento;
            CodigoMedicamento = codigoMedicamento;
            Enfermedad = enfermedad;
        }

    }
}
