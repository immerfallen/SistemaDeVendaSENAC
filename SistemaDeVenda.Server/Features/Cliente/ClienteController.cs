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

        [HttpGet]
        [ResponseCache(NoStore = true)]       
        public async Task<IActionResult> Listar(Listar.Query request)
        {
            return Json(await _mediator.Send(request));
        }        

        [HttpPost]        
        public async Task<IActionResult> Inserir([FromBody] InserirEditar.Command request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpGet]       
        public async Task<IActionResult> Editar(InserirEditar.Query request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpPut]        
        public async Task<IActionResult> Editar([FromBody] InserirEditar.Command request)
        {
            return Json(await _mediator.Send(request));
        }

        [HttpDelete]       
        public async Task Excluir([FromBody] Excluir.Command request)
        {
            await _mediator.Send(request);
        }        
    }
}