using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreProject.Core.Domain.Base;
using StoreProject.Core.Domain.Logger;

namespace StoreProject.API.ActionFilters
{
    public class ValidateProductExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager repository;
        private readonly ILoggerManager logger;
        public ValidateProductExistsAttribute(IRepositoryManager repository, ILoggerManager logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var trackChanges = (method.Equals("PUT") || method.Equals("PATCH")) ? true : false;
            var categoryId = (Guid)context.ActionArguments["categoryId"];
            var category = await repository.ProductCategory.GetProductCategoryById(categoryId, false);
            if (category == null)
            {
                logger.LogInfo($"Category with id: {categoryId} doesn't exist in the database.");

                context.Result = new NotFoundResult();
                return;
            }
            var id = (Guid)context.ActionArguments["id"];
            var product = await repository.Product.GetProductById(categoryId, id, trackChanges);
            if (product == null)
            {
                logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("product", product);
                await next();
            }

        }
    }
}
