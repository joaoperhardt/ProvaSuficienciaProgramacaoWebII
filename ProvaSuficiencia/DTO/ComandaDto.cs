namespace ProvaSuficiencia.DTO
{
    public class ComandaDto
    {
        public int id { get; set; }
        public UsuarioComandaDto usuario { get; set; }
        public List<ProdutoComandaDto> produtos { get; set; }
    }
}
