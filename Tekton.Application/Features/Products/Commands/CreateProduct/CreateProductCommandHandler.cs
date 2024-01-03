using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Tekton.Application.Contracts.Persistence;
using Tekton.Dominio;

namespace Tekton.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
            _logger = logger;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Product>(request); 

            _unitOfWork.ProductRepository.AddEntity(productEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el producto");
            }

            _logger.LogInformation($"Producto con código {productEntity.ProductId} fue creado existosamente"); 

            return productEntity.ProductId;
        }
    }
}
