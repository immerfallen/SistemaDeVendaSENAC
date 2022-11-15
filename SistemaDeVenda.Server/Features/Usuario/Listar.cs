namespace SistemaDeVenda.Server.Features.Usuario
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
            public UsuarioDto[] Usuarios { get; set; }
        }

        public class UsuarioDto
        {
            public int Id { get; set; }

            public string NomeCompleto { get; set; }

            public string Email { get; set; }           

            public string Senha { get; set; }
            
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
                UsuarioDto[] usuarioDto;

                var query = _sistemaDeVendaContext
                    .Set<Usuario>()
                    .AsNoTracking()
                    .AsQueryable();

                usuarioDto = await query
                    .Select(e => new UsuarioDto
                    {
                        Id = e.Id,                        
                        Email = e.Email,                        
                        Senha = e.Senha,
                        NomeCompleto = e.NomeCompleto
                    })
                    .OrderBy(e => e.Email)
                    .ToArrayAsync();

                return new Dto
                {
                    Usuarios = usuarioDto
                };
            }

           
        }
    }
}