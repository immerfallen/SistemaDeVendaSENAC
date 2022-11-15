namespace SistemaDeVenda.Server.Features.Produto
{
    using SistemaDeVenda.Server.Infra;
    using MediatR;
    using Domain;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Tempus.Utils;
    

    public class Excluir
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }

        public class CommandHandler : AsyncRequestHandler<Command>
        {
            readonly SistemaDeVendaContext _context;
            readonly IMediator _mediator;

            public CommandHandler(SistemaDeVendaContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            protected override async Task HandleCore(Command request)
            {
                var produto = await _context
                    .Set<Produto>()
                    .FirstOrDefaultAsync(e => e.Id == request.Id);

                ChecarSe.Encontrou(produto);

                _context.Remove(produto);
               
                await _context.SaveChangesAsync();
            }
        }
    }
}