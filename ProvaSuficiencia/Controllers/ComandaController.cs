using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvaSuficiencia.Contracts.Repository;
using ProvaSuficiencia.DTO;

namespace ProvaSuficiencia.Controllers
{
    [ApiController]
    [Route("RestAPIFurb")]
    [Authorize]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaRepository _comandaRepository;

        public ComandaController(IComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }


        [HttpGet("comanda")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _comandaRepository.GetAll());
        }

        [HttpGet("comanda/{id}")]
        public IActionResult GetById(int id)
        {
            var comanda = _comandaRepository.GetById(id);
            if (comanda == null)
                return NotFound();
            return Ok(comanda);
        }

        [HttpPost("comanda")]
        public IActionResult Create([FromBody] ComandaDto comanda)
        {
            var comandaCriada = _comandaRepository.Create(comanda);
            if (comandaCriada != null)
                return Ok(comandaCriada);
            return BadRequest("Erro ao criar comanda");
        }

        [HttpPut("comanda/{id}")]
        public IActionResult Update(int id, [FromBody] List<int> produtosId)
        {
            var result = _comandaRepository.Update(id, produtosId);
            if (result)
                return Ok();
            return BadRequest("Erro ao atualizar comanda");
        }

        [HttpDelete("comanda/{id}")]
        public IActionResult Delete(int id)
        {
            var mensagem = _comandaRepository.Delete(id);
            if (mensagem.StartsWith("Comanda deletada"))
                return Ok(new { mensagem });
            return NotFound(new { mensagem });
        }
    }
}
