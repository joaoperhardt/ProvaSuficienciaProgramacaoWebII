using ProvaSuficiencia.Contracts.Repository;
using ProvaSuficiencia.DTO;
using ProvaSuficiencia.Entitys;
using ProvaSuficiencia.Infrastructure;

namespace ProvaSuficiencia.Repository
{
    public class ProdutoRepository : Connection, IProdutoRepository
    {
        public async Task Add(ProdutoDto produtoDto)
        {
            string sql = @"
                INSERT INTO PRODUTOS (Nome, Preco)
                            VALUE (@nome, @preco)
            ";

            await Execute(sql, produtoDto);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> GetByFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
