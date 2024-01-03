using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using Tekton.Dominio;
using Tekton.Dominio.Common;

namespace Tekton.Infraestructure.Persistence
{
    public class TektonLabsDbContext : DbContext
    {
        public TektonLabsDbContext(DbContextOptions<TektonLabsDbContext> options) : base(options)
        {
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(e => e.ProductId);
            modelBuilder.Entity<Product>().Property(e => e.ProductId).UseIdentityColumn();
            modelBuilder.Entity<Product>().Property(b => b.Price).HasPrecision(14, 2);
            modelBuilder.Entity<Product>().HasData
                    (
                        new Product
                        {
                            ProductId=1,
                            CreatedBy = "alan",
                            Name = "Laptop",
                            Price = 1500M,
                            Status = 1,
                            Stock = 25,
                            Description = "Laptop lenovo"
                        },
                        new Product
                        {
                            ProductId = 2,
                            CreatedBy = "alan",
                            Name = "Computer",
                            Price = 2500M,
                            Status = 1,
                            Stock = 350,
                            Description = "Computer HP"
                        }
                    );
        }
        public DbSet<Product>? Products { get; set; }
    }
}
