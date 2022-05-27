using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using TwoFKsSameTable.Models.ExemploUm;
using TwoFKsSameTable.Models.ExemploDois;

namespace TwoFKsSameTable.Data {
   public class ApplicationDbContext : DbContext {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options) { }

      protected override void OnModelCreating(ModelBuilder modelBuilder) {
         base.OnModelCreating(modelBuilder);

         // https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties
         modelBuilder.Entity<ReceitaDois>()
                     .HasOne(m => m.Medico)
                     .WithMany(t => t.ListaReceitasCriadas)
                     .HasForeignKey(m => m.MedicoFK)
                     .IsRequired()
                     .OnDelete(DeleteBehavior.Restrict);

         modelBuilder.Entity<ReceitaDois>()
                     .HasOne(m => m.Utente)
                     .WithMany(t => t.ListaReceitasAtribuidas)
                     .HasForeignKey(m => m.UtenteFK)
                     .IsRequired()
                     .OnDelete(DeleteBehavior.Restrict);
      }


      // criar tabelas BD
      // conjunto de tabelas que utilizam as 'anotações' para especificar as FKs
      public DbSet<PessoaUm> PessoasUm { get; set; }
      public DbSet<ReceitaUm> ReceitasUm { get; set; }


      // conjunto de tabelas que utilizam 'FluentAPI' para especificar as FKs
      public DbSet<PessoaDois> PessoasDois { get; set; }
      public DbSet<ReceitaDois> ReceitasDois { get; set; }

   }
}