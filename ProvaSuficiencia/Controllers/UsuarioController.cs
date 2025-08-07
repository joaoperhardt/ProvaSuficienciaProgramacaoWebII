using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvaSuficiencia.Contracts.Repository;
using ProvaSuficiencia.DTO;

namespace ProvaSuficiencia.Controllers
{
    [ApiController]
    [Route("RestAPIFurb")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [Authorize]
        [HttpPost("usuario")]
        public async Task<IActionResult> Add(UsuarioDto usuarioDto)
        {
            try
            {
                await _usuarioRepository.Add(usuarioDto);
                return Ok(usuarioDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("usuario/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _usuarioRepository.GetById(id));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn(UsuarioLoginDto user)
        {
            try
            {
                return Ok(await _usuarioRepository.LogIn(user));
            }
            catch (Exception ex)
            {
                return Unauthorized("Email ou senha invalidos");
            }
        }
    }
}
