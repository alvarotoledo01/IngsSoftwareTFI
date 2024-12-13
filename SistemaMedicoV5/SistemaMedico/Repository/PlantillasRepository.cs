using System.Collections.Generic;
using SistemaMedicoV3.Models;

namespace SistemaMedicoV3.Repositories
{
    public class PlantillasRepository
    {
        public static List<string> PlantillasDisponibles = new List<string>
        {
             "Paciente muestra signos de mejora con reducción gradual de los síntomas.",
                "Se observa respuesta positiva al tratamiento, sin complicaciones adicionales.",
                "No se han reportado nuevos síntomas, paciente estable.",
                "Continúa tratamiento, con seguimiento clínico regular.",
                "Se han prescrito nuevos medicamentos debido a la evolución de los síntomas.",
                "Paciente muestra reacción adversa leve al tratamiento, se ajustó la medicación.",
                "Signos vitales estables, pero se recomienda continuar en observación.",
                "Se han realizado pruebas adicionales para evaluar progresión de la enfermedad.",
                "Paciente reporta mejoría en dolor y malestar general.",
                "Tratamiento sigue según lo planificado, próxima consulta programada."
};
        
    }
}
