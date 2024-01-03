using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekton.Application.Contracts.Service
{
    public interface IDiscountService
    {
        public Task<int> getDiscountProduct(int productId);
    }
}
