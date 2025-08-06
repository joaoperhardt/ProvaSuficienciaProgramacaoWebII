namespace ProvaSuficiencia.Entitys
{
    public class Comanda
    {
        private int id;
        private Usuario usuario { get; set; }
        private List<Produto> produtos { get; set; }

        public Comanda(Usuario usuario, List<Produto> produtos)
        {
            this.usuario = usuario;
            this.produtos = produtos;
        }
    }
}
