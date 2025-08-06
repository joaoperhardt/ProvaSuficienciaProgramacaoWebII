namespace ProvaSuficiencia.Entitys
{
    public class Produto
    {
        private int id;
        private string nome {  get; set; }
        private double preco { get; set; }

        public Produto(string nome, double preco)
        {
            this.nome = nome;
            this.preco = preco;
        }
    }
}
