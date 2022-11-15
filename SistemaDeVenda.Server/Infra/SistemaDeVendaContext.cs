namespace SistemaDeVenda.Server.Infra
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using SistemaDeVenda.Server.Domain;
   
    using Microsoft.EntityFrameworkCore;    

    public class SistemaDeVendaContext : DbContext
    {
        public SistemaDeVendaContext(DbContextOptions<SistemaDeVendaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Cliente>(opts =>
            {                          
                opts.HasIndex(p => new { p.Nome }).IsUnique();
            });

            modelBuilder.Entity<Vendedor>();

            modelBuilder.Entity<Usuario>();

            modelBuilder.Entity<Produto>();
        }          
    }
}