namespace ProvaSuficiencia.Entitys
{
    public class Usuario
    {
        public int Id;
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public string Email { get; set; }
        public string Senha { get; set; }

        //public Usuario(string nome, string telefone, string email, string senha)
        //{
        //    this.Nome = nome;
        //    this.Telefone = telefone;
        //    this.Email = email;
        //    this.Senha = senha;
        //}

        public string getEmail() { return this.Email; }

    }
}
