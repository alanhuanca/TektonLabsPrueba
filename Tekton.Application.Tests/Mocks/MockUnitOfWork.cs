using Microsoft.EntityFrameworkCore;
using Moq; 
using Tekton.Infraestructure.Persistence;
using Tekton.Infraestructure.Repositories;

namespace Tekton.Application.Tests.Mocks
{
    public static class MockUnitOfWork
    {


        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<TektonLabsDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{dbContextId}")
                .Options;

            var streamerDbContextFake = new TektonLabsDbContext(options);
            streamerDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(streamerDbContextFake);


            return mockUnitOfWork;
        }

    }
}
