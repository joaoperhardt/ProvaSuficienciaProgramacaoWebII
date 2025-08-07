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

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetByFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetById(int id)
        {
            string sql = "SELECT * FROM USUARIOS WHERE Id = @id";
            return await GetConnection().QueryFirstAsync<Usuario>(sql, new { id });
        }

        public Task Update(Usuario usuario)
        {
            throw new NotImplementedException();
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
