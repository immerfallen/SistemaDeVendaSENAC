namespace SistemaDeVenda.Server.Features.ItensVenda
{
    using System;
    using System.Collections.Generic;
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
            public int VendaId { get; set; }
        }

        public class Dto
        {
            public List<Venda> Vendas { get; set; }
            public List<ProdutoDto> Produtos { get; set; }
        }

        public class ProdutoDto
        {
            public int? Id { get; set; }

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

                var vendaDto = await _sistemaDeVendaContext
                    .Set<Venda>()
                    .AsNoTracking()
                    .AsQueryable()
                    .ToListAsync();

                //foreach (var venda in vendaDto)
                //{
                //    venda.
                //}

                return new Dto
                {
                    Vendas = vendaDto
                };
            }


        }
    }
}