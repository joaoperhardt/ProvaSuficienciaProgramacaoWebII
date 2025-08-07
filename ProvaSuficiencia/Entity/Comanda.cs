using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProvaSuficiencia.Entitys
{
    public class Comanda
    {
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeUsuario { get; set; }

        [Required]
        [Phone]
        public string TelefoneUsuario { get; set; }

        [Required]
        [MinLength(1)]
        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
