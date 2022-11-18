namespace SistemaDeVenda.Server.Features.Venda
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
        }

        public class Dto
        {
            public List<VendaDto> Vendas { get; set; }
        }

        public class VendaDto
        {
            public int? Id { get; set; }

            public DateTime Data { get; set; }

            public int VendedorId { get; set; }

            public int ClienteId { get; set; }

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

                var vendas = await _sistemaDeVendaContext
                    .Set<Venda>()
                    .Select(v => new VendaDto
                    {
                        Id = v.Id,
                        Data = v.Data,
                        VendedorId = v.VendedorId,
                        ClienteId = v.ClienteId,
                    })
                    .AsNoTracking()
                    .AsQueryable()
                    .ToListAsync();                

                List<ProdutoDto> produtos = new List<ProdutoDto>();

                foreach (var venda in vendas)
                {
                  var  totalItens = await _sistemaDeVendaContext
                   .Set<ItensVenda>()
                   .Where(i => i.VendaId == venda.Id)
                   .AsQueryable()
                   .ToListAsync();

                    produtos = new List<ProdutoDto>();

                    foreach (var item in totalItens)
                    {                       

                        var  produto =  _sistemaDeVendaContext.
                            Set<Produto>()
                            .Where(p => p.Id == item.ProdutoId)
                            .Select(p=> new ProdutoDto
                            {
                                QuantidadeEstoque = p.QuantidadeEstoque,
                                Descricao = p.Descricao,
                                Id =p.Id,
                                LinkFoto = p.LinkFoto,
                                Nome = p.Nome,
                                PrecoUnitario = p.PrecoUnitario,
                                UnidadeMedida = p.UnidadeMedida,                                
                            })
                            .AsQueryable()
                            .FirstOrDefault();
                        produtos.Add(produto);
                        
                    }
                    venda.Produtos = produtos;

                }


                return new Dto
                {
                    Vendas = vendas
                };
            }


        }
    }
}