using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using WEBAPI.Model;

namespace WEBAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Ordine> Ordini { get; set; }
        public DbSet<DettaglioOrdine> DettagliOrdine { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chiave composta per DettaglioOrdine
            modelBuilder.Entity<DettaglioOrdine>()
                .HasKey(d => new { d.IdOrdine, d.CodArticolo });

            // Definizione della relazione tra Ordine e DettaglioOrdine
            modelBuilder.Entity<Ordine>()
                .HasMany(o => o.DettagliOrdine) // Un Ordine ha molti DettagliOrdine
                .WithOne(d => d.Ordine) // Un DettaglioOrdine è associato a un Ordine
                .HasForeignKey(d => d.IdOrdine) // Chiave esterna
                .OnDelete(DeleteBehavior.Cascade); // Cancella i dettagli se si elimina l'ordine
        }


    }
}
