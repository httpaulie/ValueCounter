using LinguagemScriptAV2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinguagemScriptAV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContadorController : ControllerBase
    {
        private readonly ContadorService _contadorService;

        public ContadorController(ContadorService contadorService)
        {
            _contadorService = contadorService;
        }

        public record ValorRequest(string Valor);
        public record UpdateRequest(int NovaContagem);
        public record ContadorResponse(string ValorRecebido, int Contagem);

        [HttpPost]
        public IActionResult ProcessarValor([FromBody] ValorRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Valor))
            {
                return BadRequest("O valor não pode ser vazio.");
            }

            int novaContagem = _contadorService.IncrementarEObterContagem(request.Valor);
            var response = new ContadorResponse(request.Valor, novaContagem);

            return Ok(response);
        }

        [HttpGet("{valor}")]
        public IActionResult ObterValor([FromRoute] string valor)
        {
            var contagem = _contadorService.ObterContagem(valor);
            if (contagem.HasValue)
            {
                return Ok(new ContadorResponse(valor, contagem.Value));
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var todasAsContagens = _contadorService.ObterTodasAsContagens();
            return Ok(todasAsContagens);
        }

        [HttpPut("{valor}")]
        public IActionResult AtualizarValor([FromRoute] string valor, [FromBody] UpdateRequest request)
        {
            try
            {
                _contadorService.AtualizarContagem(valor, request.NovaContagem);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{valor}")]
        public IActionResult DeletarValor([FromRoute] string valor)
        {
            if (_contadorService.RemoverContagem(valor))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
