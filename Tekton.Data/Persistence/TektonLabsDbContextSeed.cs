using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekton.Dominio;

namespace Tekton.Infraestructure.Persistence
{
    public class TektonLabsDbContextSeed
    {
        public static async Task SeedAsync(TektonLabsDbContext context, ILogger<TektonLabsDbContextSeed> logger)
        {
            if (!context.Products!.Any())
            {
                context.Products!.AddRange(GetPreconfiguredProduct());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(TektonLabsDbContext).Name);
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProduct()
        {
            return new List<Product>
            {
                new Product {CreatedBy = "alan",  Name="Laptop", Price=1500M, Status=1,Stock=25, Description="Laptop lenovo"},
                new Product {CreatedBy = "alan",Name="Computer", Price=2500M,Status=1, Stock=350,Description ="Computer HP" },
            };

        }
    }
}
