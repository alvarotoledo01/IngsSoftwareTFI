using SistemaMedicoV3.Models;

namespace SistemaMedico.Repository
{
    public class MedicosRepository
    {
        private List<Medico> medicos;
        public MedicosRepository()
        {
            medicos = new List<Medico>
        {
            new Medico
            {
                CUIL = 20123456789,
                DNI = 12345678,
                MatriculaMedica = "ABC12345",
                Especialidad = "Cardiología",
                FechaNacimiento = new DateTime(1990, 6, 10),
                Telefono = 123456789,
                NombreCompleto = "Juan Pérez",
                Direccion = "Av. Siempre Viva 123",
                Localidad = "Springfield",
                Provincia = "Buenos Aires",
                Pais = "Argentina",
                Email = "usuario1@example.com"
            },
            new Medico
            {
                CUIL = 20765432109,
                DNI = 76543210,
                MatriculaMedica = "GHI90123",
                Especialidad = "Pediatría",
                FechaNacimiento = new DateTime(1980, 12, 15),
                Telefono = 1122334455,
                NombreCompleto = "Carlos García",
                Direccion = "Boulevard Central 789",
                Localidad = "Rosario",
                Provincia = "Santa Fe",
                Pais = "Argentina",
                Email = "usuario2@example.com"
            },
            new Medico
            {
                CUIL = 20876543210,
                DNI = 87654321,
                MatriculaMedica = "DEF67890",
                Especialidad = "Neurología",
                FechaNacimiento = new DateTime(1985, 4, 25),
                Telefono = 987654321,
                NombreCompleto = "María López",
                Direccion = "Calle Falsa 456",
                Localidad = "Shelbyville",
                Provincia = "Córdoba",
                Pais = "Argentina",
                Email = "usuario3@example.com"
            }
        };
        }

        public List<Medico> ObtenerMedicos()
        {
            return medicos;
        }
    }
}
