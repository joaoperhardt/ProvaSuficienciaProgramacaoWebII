using System.ComponentModel.DataAnnotations;

namespace ProvaSuficiencia.DTO
{
    public class ProdutoDto
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do produto deve ter até 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public double Preco { get; set; }
    }
}
