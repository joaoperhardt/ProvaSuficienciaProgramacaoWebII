using Dapper;
using ProvaSuficiencia.Contracts.Repository;
using ProvaSuficiencia.DTO;
using ProvaSuficiencia.Entitys;
using ProvaSuficiencia.Infrastructure;

namespace ProvaSuficiencia.Repository
{
    public class ComandaRepository : Connection, IComandaRepository
    {
        public async Task<IEnumerable<Comanda>> GetAll()
        {
            using var conn = GetConnection();
            var comandas = await conn.QueryAsync<Comanda>(
                @"SELECT c.Id, c.Usuarios_id AS UsuarioId, u.Nome as NomeUsuario, u.Telefone as TelefoneUsuario
          FROM COMANDAS c
          INNER JOIN USUARIOS u ON c.Usuarios_id = u.Id");

            foreach (var comanda in comandas)
            {
                var produtos = await conn.QueryAsync<Produto>(
                    @"SELECT p.Id, p.Nome, p.Preco
              FROM PRODUTOS p
              INNER JOIN COMANDA_PRODUTO cp ON cp.ProdutoId = p.Id
              WHERE cp.ComandaId = @ComandaId", new { ComandaId = comanda.Id });
                comanda.Produtos = produtos.ToList();
            }

            return comandas;
        }

        public Comanda GetById(int id)
        {
            using var conn = GetConnection();
            var comanda = conn.QueryFirstOrDefault<Comanda>(
                @"SELECT c.Id, c.Usuarios_id AS UsuarioId, u.Nome as NomeUsuario, u.Telefone as TelefoneUsuario
          FROM COMANDAS c
          INNER JOIN USUARIOS u ON c.Usuarios_id = u.Id
          WHERE c.Id = @id", new { id });

            if (comanda != null)
            {
                var produtos = conn.Query<Produto>(
                    @"SELECT p.Id, p.Nome, p.Preco
              FROM PRODUTOS p
              INNER JOIN COMANDA_PRODUTO cp ON cp.ProdutoId = p.Id
              WHERE cp.ComandaId = @ComandaId", new { ComandaId = comanda.Id });
                comanda.Produtos = produtos.ToList();
            }

            return comanda;
        }

        public int Create(ComandaDto comanda)
        {
            using var conn = GetConnection();
            var sql = @"INSERT INTO COMANDAS (Usuarios_id) VALUES (@UsuarioId);
                SELECT LAST_INSERT_ID();";
            var comandaId = conn.ExecuteScalar<int>(sql, new { comanda.UsuarioId });

            if (comanda.ProdutoIds != null && comanda.ProdutoIds.Any())
            {
                foreach (var produtoId in comanda.ProdutoIds)
                {
                    conn.Execute(
                        @"INSERT INTO COMANDA_PRODUTO (ComandaId, ProdutoId) VALUES (@ComandaId, @ProdutoId)",
                        new { ComandaId = comandaId, ProdutoId = produtoId });
                }
            }

            return comandaId;
        }

        public bool Update(int comandaId, List<int> produtosId)
        {
            using var conn = GetConnection();

            // Remove todos os produtos atuais da comanda
            conn.Execute("DELETE FROM COMANDA_PRODUTO WHERE ComandaId = @ComandaId", new { ComandaId = comandaId });

            // Adiciona os novos produtos
            if (produtosId != null && produtosId.Any())
            {
                foreach (var produtoId in produtosId)
                {
                    conn.Execute(
                        @"INSERT INTO COMANDA_PRODUTO (ComandaId, ProdutoId) VALUES (@ComandaId, @ProdutoId)",
                        new { ComandaId = comandaId, ProdutoId = produtoId });
                }
            }

            return true;
        }

        public bool Delete(int id)
        {
            using var conn = GetConnection();
            conn.Execute("DELETE FROM COMANDA_PRODUTO WHERE ComandaId = @ComandaId", new { ComandaId = id });
            var affected = conn.Execute("DELETE FROM COMANDAS WHERE Id = @Id", new { Id = id });
            return affected > 0;
        }
    }
}

