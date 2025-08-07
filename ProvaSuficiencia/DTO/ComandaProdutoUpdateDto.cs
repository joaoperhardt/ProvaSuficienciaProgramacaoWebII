using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProvaSuficiencia.DTO
{
    public class ComandaProdutosUpdateDto
    {
        [Required(ErrorMessage = "A lista de produtos é obrigatória.")]
        [MinLength(1, ErrorMessage = "A comanda deve conter pelo menos um produto.")]
        public List<int> ProdutoIds { get; set; } = new List<int>();
    }
}