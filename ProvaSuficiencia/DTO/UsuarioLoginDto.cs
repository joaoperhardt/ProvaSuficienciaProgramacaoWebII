using ProvaSuficiencia.Helper;

namespace ProvaSuficiencia.DTO
{
    public class UsuarioLoginDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public void ValidSenhaHash()
        {
            this.Senha = Senha.GenerateHash();
        }
    }
}
