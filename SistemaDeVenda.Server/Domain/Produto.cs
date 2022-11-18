namespace SistemaDeVenda.Server.Domain
{
    using System;   
    using System.ComponentModel.DataAnnotations;


    public class Produto
    {
        public int Id { get; set; }

        [MaxLength(45)]
        public string Nome { get; set; }       

        [MaxLength(45)]
        public string Descricao { get; set; }
        
        public decimal PrecoUnitario { get; set; }

        public decimal QuantidadeEstoque { get; set; }

        public string UnidadeMedida { get; set; }

        public string LinkFoto { get; set; }        
    }
}