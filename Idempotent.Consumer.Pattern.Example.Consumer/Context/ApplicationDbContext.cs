using Idempotent.Consumer.Pattern.Example.Consumer.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace Idempotent.Consumer.Pattern.Example.Consumer.Context
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<IdempotentEvent> IdempotentEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost, 1433;Database=IdempotentConsumerPatternDB;User ID=SA;Password=1q2w3e4r+!;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdempotentEvent>(entity =>
            {
                entity
                    .HasKey(i => i.IdempotentToken);

                entity.ToTable("Idempotent_Event");
            });
        }
    }
}
