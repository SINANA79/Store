using StoreProject.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Core.Domain.Base
{
    public interface IRepositoryManager
    {
        IProductCategoryService ProductCategory { get; }
        IProductService Product { get; }
        Task SaveAsync();

    }
}
