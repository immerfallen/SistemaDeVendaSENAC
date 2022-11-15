namespace SistemaDeVenda.Server.Features.Produto
{
    using System.Linq;
    using System.Threading.Tasks;    
    using Domain;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using SistemaDeVenda.Server.Infra;

    public class Listar
    {
        public class Query : IRequest<Dto>
        {           
        }

        public class Dto
        {
            public ProdutoDto[] Produtos { get; set; }
        }

        public class ProdutoDto
        {
            public int Id { get; set; }

            public string Nome { get; set; }           

            public string Descricao { get; set; }

            public decimal PrecoUnitario { get; set; }

            public decimal QuantidadeEstoque { get; set; }

            public string UnidadeMedida { get; set; }

            public string LinkFoto { get; set; }
        }        

        public class QueryHandler : AsyncRequestHandler<Query, Dto>
        {
            private readonly SistemaDeVendaContext _sistemaDeVendaContext;

            public QueryHandler(SistemaDeVendaContext sistemaDeVendaContext)
            {
                _sistemaDeVendaContext = sistemaDeVendaContext;
            }

            protected override async Task<Dto> HandleCore(Query request)
            {
                ProdutoDto[] produtoDto;

                var query = _sistemaDeVendaContext
                    .Set<Produto>()
                    .AsNoTracking()
                    .AsQueryable();

                produtoDto = await query
                    .Select(e => new ProdutoDto
                    {
                        Id = e.Id,
                        Nome = e.Nome,
                        Descricao = e.Descricao,                        
                        PrecoUnitario = e.PrecoUnitario,
                        QuantidadeEstoque = e.QnuantidadeEstoque,
                        UnidadeMedida = e.UnidadeMedida,
                        LinkFoto = e.LinkFoto
                    })
                    .OrderBy(e => e.Nome)
                    .ToArrayAsync();

                return new Dto
                {
                    Produtos = produtoDto
                };
            }

           
        }
    }
}