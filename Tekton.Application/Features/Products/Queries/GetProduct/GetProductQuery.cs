using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekton.Dominio;

namespace Tekton.Application.Features.Products.Queries.GetProduct
{ 
    public class GetProductQuery : IRequest<ProductDTO>
    {
        public int _ProductId { get; set; }
        public GetProductQuery(int productid)
        {
            _ProductId = productid;
        }
    }
}
