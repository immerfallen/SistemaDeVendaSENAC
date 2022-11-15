namespace SistemaDeVenda.Server.Features.Vendedor
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
            public VendedorDto[] Vendedores { get; set; }
        }

        public class VendedorDto
        {
            public int Id { get; set; }

            public string Nome { get; set; }           

            public string Senha { get; set; }

            public string Email { get; set; }
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
                VendedorDto[] vendedorDto;

                var query = _sistemaDeVendaContext
                    .Set<Vendedor>()
                    .AsNoTracking()
                    .AsQueryable();

                vendedorDto = await query
                    .Select(e => new VendedorDto
                    {
                        Id = e.Id,
                        Nome = e.Nome,
                        Email = e.Email,                        
                        Senha = e.Senha
                    })
                    .OrderBy(e => e.Nome)
                    .ToArrayAsync();

                return new Dto
                {
                    Vendedores = vendedorDto
                };
            }

           
        }
    }
}