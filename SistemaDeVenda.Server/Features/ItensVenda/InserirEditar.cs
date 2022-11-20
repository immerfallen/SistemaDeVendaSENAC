namespace SistemaDeVenda.Server.Features.ItensVenda
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

        public class Command : IRequest<int>
        {
            public int? Id { get; set; }            

            public int VendaId { get; set; }

            public int ProdutoId { get; set; }            

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
                ItensVenda itens;                

                if (!request.Id.HasValue)
                {
                    itens = new ItensVenda();                    

                    await _sistemaDeVendaContext.AddAsync(itens);                   
                }
                else
                {
                    itens = await _sistemaDeVendaContext
                        .Set<ItensVenda>()                        
                        .FirstOrDefaultAsync(e => e.Id == request.VendaId);

                    ChecarSe.Encontrou(itens);
                }

                Mapear(request, itens);                

                await _sistemaDeVendaContext.SaveChangesAsync();                   

                return itens.Id;
            }

            private void Mapear(Command request, ItensVenda itens)
            {                
                itens.ProdutoId = request.ProdutoId;
                itens.VendaId = request.VendaId;                              
            }

           
        }
    }
}