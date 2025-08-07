using System.ComponentModel.DataAnnotations;

namespace ProvaSuficiencia.Entitys
{
    public class Produto
    {
        public int Id;

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double Preco { get; set; }
    }
}
