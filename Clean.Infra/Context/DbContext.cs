using Clean.Domain.Entities;
using Clean.Infra.Context.Configurations;
using Clean.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Clean.Infra.Context
{
    public sealed partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Prevenir ações em cascata para Migrações
            modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned())
                .SelectMany(e => e.GetForeignKeys())
                .ForEach(PreventCascade);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }

        private void PreventCascade(IMutableForeignKey fk)
        {
            fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
