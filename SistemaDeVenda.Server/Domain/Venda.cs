namespace SistemaDeVenda.Server.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class Venda
    {
        public int Id { get; set; }
       
        public DateTime Data { get; set; }

        public Vendedor Vendedor { get; set; }

        public int VendedorId { get; set; }

        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }
        

    }
}