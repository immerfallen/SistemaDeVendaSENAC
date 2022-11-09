namespace SistemaDeVenda.Server.Features.Cliente
{   
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using SistemaDeVenda.Server.Domain;  
    using FluentValidation;
    using MediatR;
    using Microsoft.EntityFrameworkCore;  
    using Tempus.Utils;
    using SistemaDeVenda.Server.Infra;

    public class InserirEditar
    {
        public class Query : IRequest<Command>
        {
            public int Id { get; set; }
        }

        public class Command : IRequest<int>
        {
            public int? Id { get; set; }

            public string Nome { get; set; }         
           
        }

        public class Validacao : AbstractValidator<Cliente>
        {
            private readonly SistemaDeVendaContext _sistemaDeVendaContext;

            public Validacao(SistemaDeVendaContext sistemaDeVenda)
            {
                _sistemaDeVendaContext = sistemaDeVenda;
                Validar();
            }

            private void Validar()
            {
                RuleFor(e => e.Nome).MustAsync(NaoDuplicado).WithMessage("Cliente já cadastrado.");
               
            }

            private async Task<bool> NaoDuplicado(Cliente cliente, string nome, CancellationToken cancellationToken)
            {
                return !await _sistemaDeVendaContext
                    .Set<Cliente>()
                    .AsNoTracking()
                    .AnyAsync(e => e.Nome == cliente.Nome && e.Id != cliente.Id);
            }
        }

        public class QueryHandler : AsyncRequestHandler<Query, Command>
        {
            private readonly SistemaDeVendaContext _sistemaDeVendaContext;

            public QueryHandler(SistemaDeVendaContext sistemaDeVendaContext)
            {
                _sistemaDeVendaContext = sistemaDeVendaContext;
            }

            protected override async Task<Command> HandleCore(Query request)
            {
                var command = await _sistemaDeVendaContext
                    .Set<Cliente>()
                    .AsNoTracking()
                    .Select(e => new Command
                    {
                        Id = e.Id,                       
                        Nome = e.Nome,                       
                        
                    })
                    .FirstOrDefaultAsync(e => e.Id == request.Id);

                ChecarSe.Encontrou(command);

                return command;
            }
        }

        public class CommandHandler : AsyncRequestHandler<Command, int>
        {
            private readonly SistemaDeVendaContext _sistemaDeVendaContext;
            private readonly Validacao _validacao;
            private readonly IMediator _mediator;

            public CommandHandler(SistemaDeVendaContext sistemaDeVendaContext, Validacao validacao, IMediator mediator)
            {
                _sistemaDeVendaContext = sistemaDeVendaContext;
                _validacao = validacao;
                _mediator = mediator;
            }

            protected override async Task<int> HandleCore(Command request)
            {
                Cliente cliente;

               
                if (!request.Id.HasValue)
                {
                    cliente = new Cliente()
                    {
                       
                    };

                    await _sistemaDeVendaContext.AddAsync(cliente);

                   
                }
                else
                {
                    cliente = await _sistemaDeVendaContext
                        .Set<Cliente>()                       
                        .FirstOrDefaultAsync(e => e.Id == request.Id);

                    ChecarSe.Encontrou(cliente);
                }

                Mapear(request, cliente);

                await _validacao.ValidateAndThrowAsync(cliente);

               

                await _sistemaDeVendaContext.SaveChangesAsync();

                return cliente.Id;
            }

            private void Mapear(Command request, Cliente cliente)
            {
                cliente.Nome = request.Nome;               

            }
        }
    }
}