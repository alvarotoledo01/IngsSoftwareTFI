using SistemaMedico.Repository;
using SistemaMedicoV3.Models;
using SistemaMedicoV3.Repository;

namespace SistemaMedicoV3.Services
{
    public class AutenticarService
    {
        private readonly List<Usuario> _usuarios;
        private readonly List<Medico> _medicos;

        public AutenticarService(UsuariosRepository repositorio, MedicosRepository medicosRepositorio)
        {
            _usuarios = repositorio.ObtenerUsuarios();
            _medicos = medicosRepositorio.ObtenerMedicos();
        }

        public Usuario? BuscarPorEmail(string email)
        {
            return _usuarios.FirstOrDefault(u => u.Email == email);
        }
        public Medico? ObtenerMedicoPorEmail(string email)
        {
            return _medicos.FirstOrDefault(m => m.Email == email);
        }
        public Medico? IniciarSesion(string email, string password)
        {
            var usuario = BuscarPorEmail(email);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(password, usuario.Password))
            {
                return null;
            }
            return ObtenerMedicoPorEmail(email);
        }
    }
}
