using SistemaMedicoV3.Models;

namespace SistemaMedico.Repository
{
    public class Repo
    {
        private List<Paciente> pacientes;
        private List<Diagnostico> diagnosticos;
        public Repo(PacientesRepository pacientesRepository)
        {
            diagnosticos = new List<Diagnostico>();

            var pacientes = pacientesRepository.ObtenerPacientes();


            foreach (var paciente in pacientes)
            {
                // Crear y agregar tres diagnósticos distintos por paciente.
                var diagnostico1 = new Diagnostico("Gripe")
                {
                    Evoluciones = new List<EvolucionMedica>
                {
                    new EvolucionMedica("El paciente presenta fiebre y dolor de cabeza.", "Juan Pérez"),
                    new EvolucionMedica("La fiebre ha disminuido; se recomienda reposo.", "Carlos García")
                }
                };

                var diagnostico2 = new Diagnostico("Hipertensión")
                {
                    Evoluciones = new List<EvolucionMedica>
                {
                    new EvolucionMedica("Presión arterial elevada. Iniciar tratamiento con antihipertensivos.", "Juan Pérez"),
                    new EvolucionMedica("Presión controlada tras una semana de tratamiento.", "Carlos García")
                }
                };

                var diagnostico3 = new Diagnostico("Diabetes Tipo 2")
                {
                    Evoluciones = new List<EvolucionMedica>
                {
                    new EvolucionMedica("Glucosa elevada. Cambios en dieta y ejercicio.", "Juan Pérez"),
                    new EvolucionMedica("Mejora parcial en niveles de glucosa.", "Carlos García")
                }
                };

                diagnosticos.Add(diagnostico1);
                diagnosticos.Add(diagnostico2);
                diagnosticos.Add(diagnostico3);
            }
        }

        public List<Diagnostico> ObtenerDiagnosticos()
        {
            return diagnosticos;
        }
    }
}
