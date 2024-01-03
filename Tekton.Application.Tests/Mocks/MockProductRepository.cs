using AutoFixture;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekton.Dominio;
using Tekton.Infraestructure.Persistence;

namespace Tekton.Application.Tests.Mocks
{
    public static class MockProductRepository
    {
        public static void AddDataProductRepository(TektonLabsDbContext tektonDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var products = fixture.CreateMany<Product>().ToList();

            products.Add(fixture.Build<Product>()
               .With(tr => tr.ProductId, 8001)
               .Without(tr => tr.LastModifiedDate)
               .Create()
           );

            tektonDbContextFake.Products!.AddRange(products);
            tektonDbContextFake.SaveChanges();

        }
    }
}
