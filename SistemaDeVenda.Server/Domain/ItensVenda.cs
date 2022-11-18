namespace SistemaDeVenda.Server.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class ItensVenda
    {
        public int Id { get; set; }

        public Venda Venda { get; set; }

        public int VendaId { get; set; }

        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

    }
}