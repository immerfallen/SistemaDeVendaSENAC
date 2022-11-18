namespace SistemaDeVenda.Server.Features.Venda
{
    using System.Threading.Tasks;
    using SistemaDeVenda.Server.Infra;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    public class VendaController : Controller
    {
        private readonly IMediator _mediator;

        public VendaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/venda/listar")]
        [ResponseCache(NoStore = true)]       
        public async Task<IActionResult> Listar(Listar.Query request)
        {
            return Json(await _mediator.Send(request));
        }        

        [HttpPost("api/venda/inserir")]        
        public async Task<IActionResult> Inserir([FromBody] InserirEditar.Command request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpGet("api/venda/obterparaeditar/:id")]       
        public async Task<IActionResult> Editar(InserirEditar.Query request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpPut("api/venda/editar/:id")]        
        public async Task<IActionResult> Editar([FromBody] InserirEditar.Command request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpDelete("api/venda/excluir/:id")]
        public async Task Excluir([FromBody] Excluir.Command request)
        {
            await _mediator.Send(request);
        }
    }
}