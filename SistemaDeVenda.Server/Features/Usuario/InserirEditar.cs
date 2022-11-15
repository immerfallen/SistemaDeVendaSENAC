namespace SistemaDeVenda.Server.Features.Usuario
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

            public string Email { get; set; }

            public string Senha { get; set; }

            public string NomeCompleto { get; set; }

            public PapelEnum Papel { get; set; }

        }

        public class Validacao : AbstractValidator<Usuario>
        {
            private readonly SistemaDeVendaContext _sistemaDeVendaContext;

            public Validacao(SistemaDeVendaContext sistemaDeVenda)
            {
                _sistemaDeVendaContext = sistemaDeVenda;
                Validar();
            }

            private void Validar()
            {
                RuleFor(e => e.Email).MustAsync(NaoDuplicado).WithMessage("Usuário já cadastrado.");

            }

            private async Task<bool> NaoDuplicado(Usuario usuario, string nome, CancellationToken cancellationToken)
            {
                return !await _sistemaDeVendaContext
                    .Set<Usuario>()
                    .AsNoTracking()
                    .AnyAsync(e => e.Email == usuario.Email);
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
                    .Set<Usuario>()
                    .AsNoTracking()
                    .Select(e => new Command
                    {
                        Id = e.Id,
                        Email = e.Email,
                        Senha = e.Senha,
                        Papel = e.Papel,
                        NomeCompleto=e.NomeCompleto

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
                Usuario usuario;


                if (!request.Id.HasValue)
                {
                    usuario = new Usuario();

                    await _sistemaDeVendaContext.AddAsync(usuario);
                }
                else
                {
                    usuario = await _sistemaDeVendaContext
                        .Set<Usuario>()
                        .FirstOrDefaultAsync(e => e.Id == request.Id);

                    ChecarSe.Encontrou(usuario);
                }

                Mapear(request, usuario);

                await _validacao.ValidateAndThrowAsync(usuario);

                await _sistemaDeVendaContext.SaveChangesAsync();

                return usuario.Id;
            }

            private void Mapear(Command request, Usuario usuario)
            {
                usuario.Papel = request.Papel;
                usuario.Email = request.Email;                
                usuario.Senha = request.Senha;
                usuario.NomeCompleto = request.NomeCompleto;
            }
        }
    }
}