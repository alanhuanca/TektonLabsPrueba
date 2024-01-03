using AutoMapper;
using LazyCache;
using MediatR;
using System.Net.NetworkInformation;
using Tekton.Application.Contracts.Persistence;
using Tekton.Application.Contracts.Service;
using Tekton.Dominio;

namespace Tekton.Application.Features.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDiscountService _discountService;
        private readonly IAppCache _appCache;

        public GetProductQueryHandler(IUnitOfWork unitOfWork, IDiscountService discountService, IAppCache appCache)
        {
            _unitOfWork = unitOfWork;
            _discountService = discountService;
            _appCache = appCache;
        }
        public async Task<ProductDTO> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request._ProductId);

            var discount = await _discountService.getDiscountProduct(request._ProductId);

            Func<Task<List<StatusProduct>>> statusObjectFactory = () => PopulateStatus();
            var retVal = await _appCache.GetOrAddAsync("status", statusObjectFactory, DateTimeOffset.Now.AddMinutes(5));


            ProductDTO productDTO = new ProductDTO
            {
                ProductId = product.ProductId,
                CreatedBy = product.CreatedBy,
                CreatedDate = product.CreatedDate,
                Description = product.Description,
                Discount = discount,
                FinalPrice = product.Price * (100.0M - discount) / 100.0M,
                LastModifiedBy = product.LastModifiedBy,
                LastModifiedDate = product.LastModifiedDate,
                Name = product.Name,
                Price = product.Price,
                StatusName = retVal.Where(x => x.Status == product.Status).First().StatusName,
                Stock = product.Stock

            };
            return productDTO;
        }

        private async Task<List<StatusProduct>> PopulateStatus()
        {
            List<StatusProduct> status = new List<StatusProduct>
            {
                new StatusProduct
                {
                     StatusName="Active",
                      Status=1

                },
                new StatusProduct
                {
                     Status=0,
                      StatusName="Inactive"
                }
            };
            return status;
        }
    }
}
