using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekton.Application.Contracts.Persistence;
using Tekton.Application.Exceptions;
using Tekton.Dominio;

namespace Tekton.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductCommandHandler> _logger;


        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
        { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);

            if (productToUpdate == null)
            {
                _logger.LogError($"No se encontro el producto id {request.ProductId}");
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            _mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(Product));

            _unitOfWork.ProductRepository.UpdateEntity(productToUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa actualizando el producto {request.ProductId}");
             
        }
    }
}
