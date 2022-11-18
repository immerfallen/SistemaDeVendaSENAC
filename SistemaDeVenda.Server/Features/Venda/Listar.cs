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
            public int VendaId { get; set; }
        }

        public class Dto
        {
            public List<Venda> Vendas { get; set; }
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
              

                return new Dto
                {
                    Vendas = vendaDto
                };
            }

           
        }
    }
}