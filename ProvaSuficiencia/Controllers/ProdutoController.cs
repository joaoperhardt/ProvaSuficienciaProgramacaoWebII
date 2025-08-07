using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvaSuficiencia.Contracts.Repository;
using ProvaSuficiencia.DTO;

namespace ProvaSuficiencia.Controllers
{
    [Authorize]
    [ApiController]
    [Route("RestAPIFurb")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost("produto")]
        public async Task<IActionResult> Add(ProdutoDto produtoDto)
        {
            try
            {
                await _produtoRepository.Add(produtoDto);
                return Ok(produtoDto);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
    }
}
