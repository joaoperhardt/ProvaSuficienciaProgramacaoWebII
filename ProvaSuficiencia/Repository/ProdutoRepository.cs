using ProvaSuficiencia.Contracts.Repository;
using ProvaSuficiencia.DTO;
using ProvaSuficiencia.Entitys;
using ProvaSuficiencia.Infrastructure;
using Dapper;

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

        public async Task Delete(int id)
        {
            using var conn = GetConnection();
            await conn.ExecuteAsync("DELETE FROM PRODUTOS WHERE Id = @id", new { id });
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<Produto>("SELECT * FROM PRODUTOS");
        }

        public async Task<IEnumerable<Produto>> GetByFilter(string filter)
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<Produto>(
                "SELECT * FROM PRODUTOS WHERE Nome LIKE @filtro",
                new { filtro = "%" + filter + "%" });
        }

        public async Task<Produto> GetById(int id)
        {
            using var conn = GetConnection();
            return await conn.QueryFirstOrDefaultAsync<Produto>("SELECT * FROM PRODUTOS WHERE Id = @id", new { id });
        }

        public async Task Update(Produto produto)
        {
            using var conn = GetConnection();
            await conn.ExecuteAsync(
                "UPDATE PRODUTOS SET Nome = @Nome, Preco = @Preco WHERE Id = @Id",
                produto);
        }
    }
}
