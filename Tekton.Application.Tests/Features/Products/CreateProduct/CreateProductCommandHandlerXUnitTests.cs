using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekton.Application.Features.Products.Commands.CreateProduct;
using Tekton.Application.Mappings;
using Tekton.Application.Tests.Mocks;
using Tekton.Infraestructure.Repositories;
using Xunit;

namespace Tekton.Application.Tests.Features.Products.CreateProduct
{
    public class CreateProductCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork; 
        private readonly Mock<ILogger<CreateProductCommandHandler>> _logger;

        public CreateProductCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper(); 

            _logger = new Mock<ILogger<CreateProductCommandHandler>>();


            MockProductRepository.AddDataProductRepository(_unitOfWork.Object.TektonLabsDbContext);
        }

        [Fact]
        public async Task CreateProductCommand_InputProduct_ReturnsNumber()
        {
            var productInput = new CreateProductCommand
            {
                Name = "name",
                Description = "description",
                Status   =1,
                Price = 150,
                Stock=89
            };

            var handler = new CreateProductCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);

            var result = await handler.Handle(productInput, CancellationToken.None);

            result.ShouldBeOfType<int>();
        }


    }
}
