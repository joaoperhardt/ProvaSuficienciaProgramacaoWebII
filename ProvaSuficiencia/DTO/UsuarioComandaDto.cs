using System.ComponentModel.DataAnnotations;

namespace ProvaSuficiencia.DTO
{
    public class UsuarioComandaDto
    {
        [Required(ErrorMessage = "O id do usuário é obrigatório.")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do usuário deve ter até 100 caracteres.")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O telefone do usuário é obrigatório.")]
        [Phone(ErrorMessage = "Telefone inválido.")]
        public string TelefoneUsuario { get; set; }
    }
}
