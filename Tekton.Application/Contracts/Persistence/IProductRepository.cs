    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekton.Dominio;

namespace Tekton.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}
