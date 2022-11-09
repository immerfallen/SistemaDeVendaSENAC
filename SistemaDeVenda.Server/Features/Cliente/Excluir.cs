namespace SistemaDeVenda.Server.Features.Cliente
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
                var cliente = await _context
                    .Set<Cliente>()
                    .FirstOrDefaultAsync(e => e.Id == request.Id);

                ChecarSe.Encontrou(cliente);

                _context.Remove(cliente);
               
                await _context.SaveChangesAsync();
            }
        }
    }
}