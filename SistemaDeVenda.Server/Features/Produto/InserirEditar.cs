namespace SistemaDeVenda.Server.Features.Produto
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

            public string Descricao { get; set; }

            public decimal PrecoUnitario { get; set; }

            public decimal QuantidadeEstoque { get; set; }

            public string UnidadeMedida { get; set; }

            public string LinkFoto { get; set; }

        }

        public class Validacao : AbstractValidator<Produto>
        {
            private readonly SistemaDeVendaContext _sistemaDeVendaContext;

            public Validacao(SistemaDeVendaContext sistemaDeVenda)
            {
                _sistemaDeVendaContext = sistemaDeVenda;
                Validar();
            }

            private void Validar()
            {
                RuleFor(e => e.Nome).MustAsync(NaoDuplicado).WithMessage("Produto já cadastrado.");
               
            }

            private async Task<bool> NaoDuplicado(Produto produto, string nome, CancellationToken cancellationToken)
            {
                return !await _sistemaDeVendaContext
                    .Set<Produto>()
                    .AsNoTracking()
                    .AnyAsync(e => e.Nome == produto.Nome);
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
                    .Set<Produto>()
                    .AsNoTracking()
                    .Select(e => new Command
                    {
                        Id = e.Id,
                        Nome = e.Nome,
                        Descricao = e.Descricao,
                        PrecoUnitario = e.PrecoUnitario,
                        QuantidadeEstoque = e.QuantidadeEstoque,
                        UnidadeMedida = e.UnidadeMedida,
                        LinkFoto = e.LinkFoto                                                 
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
                Produto produto;
               
                if (!request.Id.HasValue)
                {
                    produto = new Produto();                    

                    await _sistemaDeVendaContext.AddAsync(produto);                   
                }
                else
                {
                    produto = await _sistemaDeVendaContext
                        .Set<Produto>()                       
                        .FirstOrDefaultAsync(e => e.Id == request.Id);

                    ChecarSe.Encontrou(produto);
                }

                Mapear(request, produto);

                await _validacao.ValidateAndThrowAsync(produto);               

                await _sistemaDeVendaContext.SaveChangesAsync();

                return produto.Id;
            }

            private void Mapear(Command request, Produto produto)
            {
                produto.Nome = request.Nome;
                produto.Descricao = request.Descricao;
                produto.PrecoUnitario = request.PrecoUnitario;
                produto.QuantidadeEstoque = request.QuantidadeEstoque;
                produto.UnidadeMedida = request.UnidadeMedida;
                produto.LinkFoto = request.LinkFoto;                
            }
        }
    }
}