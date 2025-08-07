using ProvaSuficiencia.Entitys;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProvaSuficiencia.DTO
{
    public class ComandaDto
    {
        [Required(ErrorMessage = "O id do usuário é obrigatório.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "A lista de produtos é obrigatória.")]
        [MinLength(1, ErrorMessage = "A comanda deve conter pelo menos um produto.")]
        public List<int> ProdutoIds { get; set; } = new List<int>();
    }
}
