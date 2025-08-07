using ProvaSuficiencia.Helper;
using System.ComponentModel.DataAnnotations;

namespace ProvaSuficiencia.DTO
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        public string Senha { get; set; }

        public void ValidSenhaHash()
        {
            this.Senha = Senha.GenerateHash();
        }
    }
}
