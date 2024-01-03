using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekton.Dominio.Common;

namespace Tekton.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {

        IProductRepository ProductRepository { get; } 

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
