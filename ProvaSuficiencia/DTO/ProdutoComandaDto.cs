using System.ComponentModel.DataAnnotations;

namespace ProvaSuficiencia.DTO
{
    public class ProdutoComandaDto
    {
        [Required(ErrorMessage = "O id do produto é obrigatório.")]
        public int id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do produto deve ter até 100 caracteres.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public double preco { get; set; }
    }
}
