using GestaoProdutos.Application.Queries.ObterFornecedor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoProdutos.API.Controllers
{
    [ApiController]
    [Route("api/fornecedores")]
    public class FornecedorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FornecedorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObterFornecedor([FromQuery] int limitePorPagina = 5, [FromQuery] int numeroDaPagina = 1)
        {
            var query = new ObterFornecedoresQuery(limitePorPagina, numeroDaPagina);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
