using StoreProject.Core.Domain.Base;
using StoreProject.Core.Domain.Products;
using StoreProject.Infra.Data.Common;
using StoreProject.Infra.Data.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Infra.Data.Base
{
    public class RepositoryManager : IRepositoryManager
    {
        private StoreDbContext storeDbContext;
        private IProductCategoryService productCategoryService;
        private IProductService productService;

        public RepositoryManager(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        } 

        public IProductCategoryService ProductCategory
        {
            get
            {
                if (productCategoryService == null)
                    productCategoryService = new ProductCategoryService(storeDbContext);
                return productCategoryService;
            }
        }

        public IProductService Product
        {
            get
            {
                if (productService == null)
                    productService = new ProductService(storeDbContext);
                return productService;
            }
        }

        public Task SaveAsync() => storeDbContext.SaveChangesAsync(); 
        
    }
}
