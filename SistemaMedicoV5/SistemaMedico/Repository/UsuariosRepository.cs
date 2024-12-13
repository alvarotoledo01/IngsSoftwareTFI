using SistemaMedicoV3.Models;

namespace SistemaMedicoV3.Repository
{
    public class UsuariosRepository
    {
        private List<Usuario> usuarios;
        public UsuariosRepository()
        {
            usuarios = new List<Usuario>
        {
            new Usuario(
            email: "usuario1@example.com",
            password: BCrypt.Net.BCrypt.HashPassword("Password1")
            ),
            new Usuario(
             email: "usuario2@example.com",
             password: BCrypt.Net.BCrypt.HashPassword("Password2")   
            ),
            new Usuario(
             email: "usuario3@example.com",
             password: BCrypt.Net.BCrypt.HashPassword("Password3")   
            )
        };
        
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }
    }     
}
