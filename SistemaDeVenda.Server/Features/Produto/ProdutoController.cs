namespace SistemaDeVenda.Server.Features.Produto
{
    using System.Threading.Tasks;
    using SistemaDeVenda.Server.Infra;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    public class ProdutoController : Controller
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/produto/listar")]
        [ResponseCache(NoStore = true)]       
        public async Task<IActionResult> Listar(Listar.Query request)
        {
            return Json(await _mediator.Send(request));
        }        

        [HttpPost("api/produto/inserir")]        
        public async Task<IActionResult> Inserir([FromBody] InserirEditar.Command request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpGet("api/produto/obterparaeditar/:id")]       
        public async Task<IActionResult> Editar(InserirEditar.Query request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpPut("api/produto/editar/:id")]        
        public async Task<IActionResult> Editar([FromBody] InserirEditar.Command request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpDelete("api/produto/excluir/:id")]
        public async Task Excluir([FromBody] Excluir.Command request)
        {
            await _mediator.Send(request);
        }
    }
}