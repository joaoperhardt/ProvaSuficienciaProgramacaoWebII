using System.ComponentModel.DataAnnotations;

namespace ProvaSuficiencia.Entitys
{
    public class Usuario
    {
        public int Id;

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Senha { get; set; }

        public string getEmail() { return this.Email; }
    }
}
