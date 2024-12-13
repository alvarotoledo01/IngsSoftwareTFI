namespace SistemaMedicoV3.Models
{
    public class Usuario
    {
        public string? Email { get; set; }
        public string? Password{ get; set; }

        public Usuario(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
