using ProvaSuficiencia.Entitys;

namespace ProvaSuficiencia.DTO
{
    public class ComandaDto
    {
        public int UsuarioId { get; set; }
        public List<int> ProdutoIds { get; set; } = new List<int>();

    }
}
