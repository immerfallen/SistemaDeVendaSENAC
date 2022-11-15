namespace SistemaDeVenda.Server.Features.Login
{
    using System.Threading.Tasks;
    using SistemaDeVenda.Server.Infra;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost("api/login/verificalogin")]
        public async Task<IActionResult> VerificaLogin([FromBody] VerificaLogin.Query request)
        {
            return Json(await _mediator.Send(request));
        }

        
    }
}