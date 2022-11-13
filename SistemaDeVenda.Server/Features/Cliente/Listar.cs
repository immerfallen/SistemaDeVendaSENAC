namespace SistemaDeVenda.Server.Features.Cliente
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
            public ClienteDto[] Clientes { get; set; }
        }

        public class ClienteDto
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public string CPF_CNPJ { get; set; }

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
                ClienteDto[] clienteDto;

                var query = _sistemaDeVendaContext
                    .Set<Cliente>()
                    .AsNoTracking()
                    .AsQueryable();

                clienteDto = await query
                    .Select(e => new ClienteDto
                    {
                        Id = e.Id,
                        Nome = e.Nome,
                        Email = e.Email,
                        CPF_CNPJ = e.CPF_CNPJ,
                        Senha = e.Senha
                    })
                    .OrderBy(e => e.Nome)
                    .ToArrayAsync();

                return new Dto
                {
                    Clientes = clienteDto
                };
            }

           
        }
    }
}