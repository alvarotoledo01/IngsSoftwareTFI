namespace SistemaMedicoV3.Models
{
    public class PedidosLaboratorio
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Plantilla { get; set; }

        public PedidosLaboratorio(string plantilla)
        {
            Plantilla = plantilla;
        }
    }
}
