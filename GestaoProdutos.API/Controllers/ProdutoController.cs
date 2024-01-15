using GestaoProdutos.Application.Commands.EditarProduto;
using GestaoProdutos.Application.Commands.ExcluirProduto;
using GestaoProdutos.Application.Commands.InserirProduto;
using GestaoProdutos.Application.Queries.ObterProdutoPorId;
using GestaoProdutos.Application.Queries.ObterProdutos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoProdutos.API.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public ProdutoController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        public async Task<IActionResult> ObterProdutos([FromQuery] int limitePorPagina = 5, [FromQuery] int numeroDaPagina = 1)
        {
            var query = new ObterProdutosQuery(limitePorPagina, numeroDaPagina);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterProdutoPorId(int id)
        {
            var query = new ObterProdutoPorIdQuery(id);
            var result = await _mediatR.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Inserir(InserirProdutoCommand command)
        {
            var result = await _mediatR.Send(command);
            return Created(string.Empty, result);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(EditarProdutoCommand command)
        {
            await _mediatR.Send(command);
            return Accepted();
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(ExcluirProdutoCommand command)
        {
            await _mediatR.Send(command);
            return Ok();
        }
    }
}
