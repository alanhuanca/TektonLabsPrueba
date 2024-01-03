using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekton.Application.Contracts.Persistence;
using Tekton.Dominio;
using Tekton.Infraestructure.Persistence;

namespace Tekton.Infraestructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(TektonLabsDbContext context) : base(context)
        { }
    }
}
