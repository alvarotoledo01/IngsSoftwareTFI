namespace SistemaMedicoV3.Models
{
    [Serializable]
    public class Medico
    {
            public Guid Id { get; set; } = Guid.NewGuid();
            public long CUIL { get; set; }
            public int DNI { get; set; }
            public string MatriculaMedica { get; set; }
            public string Especialidad { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public int Telefono { get; set; }
            public string NombreCompleto { get; set; }
            public string Direccion { get; set; }
            public string Localidad { get; set; }
            public string Provincia { get; set; }
            public string Pais { get; set; }
            public string Email { get; set; }

            public Medico() { }

            public Medico(long cuil, int dni, string matriculaMedica, string especialidad, DateTime fechaNacimiento,
                          int telefono, string nombreCompleto, string direccion, string localidad,
                          string provincia, string pais, string email)
            {
                CUIL = cuil;
                DNI = dni;
                MatriculaMedica = matriculaMedica;
                Especialidad = especialidad;
                FechaNacimiento = fechaNacimiento;
                Telefono = telefono;
                NombreCompleto = nombreCompleto;
                Direccion = direccion;
                Localidad = localidad;
                Provincia = provincia;
                Pais = pais;
                Email = email;
            }
        }
}
