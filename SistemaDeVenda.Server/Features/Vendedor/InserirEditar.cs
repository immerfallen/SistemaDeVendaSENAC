namespace SistemaDeVenda.Server.Features.Vendedor
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

            public string Email { get; set; }

            public string Senha { get; set; }

        }

        public class Validacao : AbstractValidator<Vendedor>
        {
            private readonly SistemaDeVendaContext _sistemaDeVendaContext;

            public Validacao(SistemaDeVendaContext sistemaDeVenda)
            {
                _sistemaDeVendaContext = sistemaDeVenda;
                Validar();
            }

            private void Validar()
            {
                RuleFor(e => e.Nome).MustAsync(NaoDuplicado).WithMessage("Vendedor já cadastrado.");
               
            }

            private async Task<bool> NaoDuplicado(Vendedor vendedor, string nome, CancellationToken cancellationToken)
            {
                return !await _sistemaDeVendaContext
                    .Set<Vendedor>()
                    .AsNoTracking()
                    .AnyAsync(e => e.Nome == vendedor.Nome && e.Id != vendedor.Id);
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
                    .Set<Vendedor>()
                    .AsNoTracking()
                    .Select(e => new Command
                    {
                        Id = e.Id,                       
                        Nome = e.Nome,
                        Email = e.Email,
                        Senha = e.Senha,                        
                        
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
                Vendedor vendedor;

               
                if (!request.Id.HasValue)
                {
                    vendedor = new Vendedor();                    

                    await _sistemaDeVendaContext.AddAsync(vendedor);                   
                }
                else
                {
                    vendedor = await _sistemaDeVendaContext
                        .Set<Vendedor>()                       
                        .FirstOrDefaultAsync(e => e.Id == request.Id);

                    ChecarSe.Encontrou(vendedor);
                }

                Mapear(request, vendedor);

                await _validacao.ValidateAndThrowAsync(vendedor);               

                await _sistemaDeVendaContext.SaveChangesAsync();

                return vendedor.Id;
            }

            private void Mapear(Command request, Vendedor vendedor)
            {
                vendedor.Nome = request.Nome;
                vendedor.Email = request.Email;                
                vendedor.Senha = request.Senha;
            }
        }
    }
}