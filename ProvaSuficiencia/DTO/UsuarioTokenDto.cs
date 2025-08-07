using ProvaSuficiencia.Entitys;

namespace ProvaSuficiencia.DTO
{
    public class UsuarioTokenDto
    {
        public string Token { get; set; }
        public Usuario Usuario { get; set; }
    }
}
