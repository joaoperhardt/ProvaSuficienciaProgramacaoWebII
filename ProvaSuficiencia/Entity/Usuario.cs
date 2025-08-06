namespace ProvaSuficiencia.Entitys
{
    public class Usuario
    {
        private int Id;
        private string Nome { get; set; }
        private string Telefone { get; set; }

        private string Email { get; set; }
        private string Senha { get; set; }

        public Usuario(string nome, string telefone, string email, string senha)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
            this.Telefone = telefone;
            this.Senha = senha;
        }

        public string getEmail() { return this.Email; }

    }
}
