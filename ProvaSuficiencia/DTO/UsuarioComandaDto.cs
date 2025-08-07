using System.ComponentModel.DataAnnotations;

namespace ProvaSuficiencia.DTO
{
    public class UsuarioComandaDto
    {
        [Required(ErrorMessage = "O id do usuário é obrigatório.")]
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do usuário deve ter até 100 caracteres.")]
        public string nomeUsuario { get; set; }

        [Required(ErrorMessage = "O telefone do usuário é obrigatório.")]
        [Phone(ErrorMessage = "Telefone inválido.")]
        public string telefoneUsuario { get; set; }
    }
}
