namespace SistemaDeVenda.Server.Features.Vendedor
{
    using System.Threading.Tasks;
    using SistemaDeVenda.Server.Infra;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    public class VendedorController : Controller
    {
        private readonly IMediator _mediator;

        public VendedorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/vendedor/listar")]
        [ResponseCache(NoStore = true)]       
        public async Task<IActionResult> Listar(Listar.Query request)
        {
            return Json(await _mediator.Send(request));
        }        

        [HttpPost("api/vendedor/inserir")]        
        public async Task<IActionResult> Inserir([FromBody] InserirEditar.Command request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpGet("api/vendedor/obterparaeditar/:id")]       
        public async Task<IActionResult> Editar(InserirEditar.Query request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpPut("api/vendedor/editar/:id")]        
        public async Task<IActionResult> Editar([FromBody] InserirEditar.Command request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpDelete("api/vendedor/excluir/:id")]
        public async Task Excluir([FromBody] Excluir.Command request)
        {
            await _mediator.Send(request);
        }
    }
}