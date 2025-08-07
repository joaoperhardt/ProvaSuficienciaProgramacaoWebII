using ProvaSuficiencia.DTO;
using ProvaSuficiencia.Entitys;

namespace ProvaSuficiencia.Contracts.Repository
{
    public interface IUsuarioRepository
    {
        Task Add(UsuarioDto usuarioDto);
        Task Update(Usuario usuario);
        Task Delete(int id);
        Task<IEnumerable<Usuario>> Get();
        Task<IEnumerable<Usuario>> GetByFilter(string filter);
        Task<Usuario> GetById(int id);
        Task<UsuarioTokenDto> LogIn(UsuarioLoginDto user);

    }
}
