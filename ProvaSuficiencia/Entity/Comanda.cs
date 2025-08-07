namespace ProvaSuficiencia.Entitys
{
    public class Comanda
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
