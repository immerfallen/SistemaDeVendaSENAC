namespace SistemaDeVenda.Server.Domain
{
    using System;   
    using System.ComponentModel.DataAnnotations;


    public enum PapelEnum
    {
        Vendedor = 0,
        Cliente = 1,
        GerenteDeVendas = 2,
        Administrador = 3

    }
}