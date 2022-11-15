namespace SistemaDeVenda.Server.Features.Usuario
{
    using System.Threading.Tasks;
    using SistemaDeVenda.Server.Infra;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    public class UsuarioController : Controller
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/usuario/listar")]
        [ResponseCache(NoStore = true)]       
        public async Task<IActionResult> Listar(Listar.Query request)
        {
            return Json(await _mediator.Send(request));
        }        

        [HttpPost("api/usuario/inserir")]        
        public async Task<IActionResult> Inserir([FromBody] InserirEditar.Command request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpGet("api/usuario/obterparaeditar/:id")]       
        public async Task<IActionResult> Editar(InserirEditar.Query request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpPut("api/usuario/editar/:id")]        
        public async Task<IActionResult> Editar([FromBody] InserirEditar.Command request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpDelete("api/usuario/excluir/:id")]
        public async Task Excluir([FromBody] Excluir.Command request)
        {
            await _mediator.Send(request);
        }
    }
}