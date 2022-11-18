namespace SistemaDeVenda.Server.Features.Venda
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
    using System;
    using System.Collections.Generic;

    public class InserirEditar
    {
        public class Query : IRequest<Command>
        {
            public int Id { get; set; }
        }

        public class Command : IRequest<int>
        {
            public int? Id { get; set; }

            public DateTime Data { get; set; }

            public int VendedorId { get; set; }

            public int ClienteId { get; set; }

            public List<Produto> Produtos { get; set; }

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
                    .Set<Venda>()
                    .AsNoTracking()
                    .Select(e => new Command
                    {
                        Id = e.Id,
                        ClienteId = e.ClienteId,
                        Data = e.Data,                        
                        VendedorId = e.VendedorId,                        
                    })
                    .FirstOrDefaultAsync(e => e.Id == request.Id);

                ChecarSe.Encontrou(command);

                return command;
            }
        }

        public class CommandHandler : AsyncRequestHandler<Command, int>
        {
            private readonly SistemaDeVendaContext _sistemaDeVendaContext;
           
            private readonly IMediator _mediator;

            public CommandHandler(SistemaDeVendaContext sistemaDeVendaContext, IMediator mediator)
            {
                _sistemaDeVendaContext = sistemaDeVendaContext;                
                _mediator = mediator;
            }

            protected override async Task<int> HandleCore(Command request)
            {
                Venda venda;

                

                if (!request.Id.HasValue)
                {
                    venda = new Venda();                    

                    await _sistemaDeVendaContext.AddAsync(venda);                   
                }
                else
                {
                    venda = await _sistemaDeVendaContext
                        .Set<Venda>()
                        .FirstOrDefaultAsync(e => e.Id == request.Id);

                    ChecarSe.Encontrou(venda);
                }

                Mapear(request, venda);                

                await _sistemaDeVendaContext.SaveChangesAsync();

                ItensVenda itens = new ItensVenda();

                await _sistemaDeVendaContext.AddAsync(itens);

                MapearItens(request, venda, itens);

                await _sistemaDeVendaContext.SaveChangesAsync();

                return venda.Id;
            }

            private void Mapear(Command request, Venda venda)
            {                
                venda.ClienteId = request.ClienteId;
                venda.Data = request.Data;
                venda.VendedorId = request.VendedorId;                
            }

            private void MapearItens(Command request, Venda venda, ItensVenda itens)
            {
                itens.VendaId = venda.Id;

                foreach (var produto in request.Produtos)
                {
                    itens.ProdutoId = produto.Id;
                }
            }
        }
    }
}