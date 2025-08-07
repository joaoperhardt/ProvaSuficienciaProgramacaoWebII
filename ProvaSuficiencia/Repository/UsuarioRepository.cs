using Dapper;
using ProvaSuficiencia.Contracts.Repository;
using ProvaSuficiencia.DTO;
using ProvaSuficiencia.Entitys;
using ProvaSuficiencia.Infrastructure;

namespace ProvaSuficiencia.Repository
{
    public class UsuarioRepository : Connection, IUsuarioRepository
    {
        public async Task Add(UsuarioDto usuarioDto)
        {
            string sql = @"
                INSERT INTO USUARIOS (Nome, Telefone, Email, Senha)
                            VALUE (@nome, @telefone, @email, @senha)
            ";
            usuarioDto.SetSenhaHash();
            await Execute(sql, usuarioDto);
        }

        public async Task Delete(int id)
        {
            using var conn = GetConnection();
            await conn.ExecuteAsync("DELETE FROM USUARIOS WHERE Id = @id", new { id });
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<Usuario>("SELECT * FROM USUARIOS");
        }

        public async Task<IEnumerable<Usuario>> GetByFilter(string filter)
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<Usuario>(
                "SELECT * FROM USUARIOS WHERE Nome LIKE @filtro OR Email LIKE @filtro",
                new { filtro = "%" + filter + "%" });
        }

        public async Task<Usuario> GetById(int id)
        {
            string sql = "SELECT * FROM USUARIOS WHERE Id = @id";
            return await GetConnection().QueryFirstOrDefaultAsync<Usuario>(sql, new { id });
        }

        public async Task Update(Usuario usuario)
        {
            using var conn = GetConnection();
            await conn.ExecuteAsync(
                "UPDATE USUARIOS SET Nome = @Nome, Telefone = @Telefone, Email = @Email WHERE Id = @Id",
                usuario);
        }

        public async Task<UsuarioTokenDto> LogIn(UsuarioLoginDto user)
        {
            string sql = "SELECT * FROM USUARIOS WHERE Email = @Email AND Senha = @Senha";
            user.ValidSenhaHash();
            Usuario userLogin = await GetConnection().QueryFirstAsync<Usuario>(sql, user);
            return new UsuarioTokenDto
            {
                Token = Authentication.GenerateToken(userLogin),
                Usuario = userLogin
            };
        }
    }
}
