namespace SistemaDeVenda.Server.Features.Cliente
{
    using System.Threading.Tasks;
    using SistemaDeVenda.Server.Infra;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    public class ClienteController : Controller
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/cliente/listar")]
        [ResponseCache(NoStore = true)]       
        public async Task<IActionResult> Listar(Listar.Query request)
        {
            return Json(await _mediator.Send(request));
        }        

        [HttpPost("api/cliente/inserir")]        
        public async Task<IActionResult> Inserir([FromBody] InserirEditar.Command request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpGet("api/cliente/obterparaeditar/:id")]       
        public async Task<IActionResult> Editar(InserirEditar.Query request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpPut("api/cliente/editar/:id")]        
        public async Task<IActionResult> Editar([FromBody] InserirEditar.Command request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpDelete("api/cliente/excluir/:id")]
        public async Task Excluir([FromBody] Excluir.Command request)
        {
            await _mediator.Send(request);
        }
    }
}