namespace SistemaDeVenda.Server.Features.Login
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

    public class VerificaLogin
    {
        public class Query : IRequest<Command>
        {
            public string Email { get; set; }

            public string Senha { get; set; }
        }

        public class Command : IRequest<int>
        {                   

            public string Email { get; set; }            

            public PapelEnum Papel { get; set; }

        }

        public class Validacao : AbstractValidator<Usuario>
        {
            private readonly SistemaDeVendaContext _sistemaDeVendaContext;

            public Validacao(SistemaDeVendaContext sistemaDeVenda)
            {
                _sistemaDeVendaContext = sistemaDeVenda;
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
                    .Where(e => e.Email == request.Email && e.Senha == request.Senha)
                    .Select(e => new Command
                    {                       
                        Email = e.Email,                        
                        Papel = e.Papel
                        
                    })
                    .FirstOrDefaultAsync();               

                return command;
            }
        }      
    }
}