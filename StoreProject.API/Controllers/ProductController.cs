using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreProject.API.ActionFilters;
using StoreProject.Core.Domain.Base;
using StoreProject.Core.Domain.Logger;
using StoreProject.Core.Domain.Products;
using StoreProject.Core.Domain.Products.Dtos;

namespace StoreProject.API.Controllers
{
    //[Route("api/productCategory/{categoryId}/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryManager repository;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;

        public ProductController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet("api/product")]
        public async Task<IActionResult> GetAllProducts(bool trackChanges)
        {
            var productsFromDb = await repository.Product.GetAllProducts(trackChanges: false);
            var productsDto = mapper.Map<IEnumerable<ProductCIdDto>>(productsFromDb);
            return Ok(productsDto);
        }

        [HttpGet("api/productCategory/{categoryId}/product")]
        public async Task<IActionResult> GetAllProductsById(Guid categoryId, bool trackChanges)
        {
            var category = await repository.ProductCategory.GetProductCategoryById(categoryId, trackChanges:
                false);
            if (category == null)
            {
                logger.LogInfo($"Category with id: {categoryId} doesn't exist in the database.");
                return NotFound();
            }
            var productsFromDb = await repository.Product.GetAllProductsById(categoryId, trackChanges: false);
            var productsDto = mapper.Map<IEnumerable<ProductDto>>(productsFromDb);
            return Ok(productsDto);
        }

        [HttpGet("api/productCategory/{categoryId}/productAdmin")]
        public async Task<IActionResult> GetAllProductsByIdForAdmin(Guid categoryId, bool trackChanges)
        {
            var category = await repository.ProductCategory.GetProductCategoryById(categoryId, trackChanges:
                false);
            if (category == null)
            {
                logger.LogInfo($"Category with id: {categoryId} doesn't exist in the database.");
                return NotFound();
            }
            var productsFromDb = await repository.Product.GetAllProductsByIdForAdmin(categoryId, trackChanges: false);
            var productsDto = mapper.Map<IEnumerable<ProductDto>>(productsFromDb);
            return Ok(productsDto);
        }

        [HttpGet("api/productCategory/{categoryId}/product/{id}", Name = "GetProductById")]
        
        public async Task<IActionResult> GetProduct(Guid categoryId, Guid id)
        {
            var category = await repository.ProductCategory.GetProductCategoryById(categoryId, trackChanges: false);
            if (category == null)
            {
                logger.LogInfo($"Category with id: {categoryId} doesn't exist in the database.");
                return NotFound();
            }

            var productDb = await repository.Product.GetProductById(categoryId, id, trackChanges: false);
            if (productDb == null)
            {
                logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var product = mapper.Map<ProductDto>(productDb);
            return Ok(product);
        }

        [HttpPost("api/productCategory/{categoryId}/product")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProduct(Guid categoryId, [FromBody] ProductForCreationDto product)
        {
            var category = await repository.ProductCategory.GetProductCategoryById(categoryId, trackChanges: false);
            if (category == null)
            {
                logger.LogInfo($"Category with id: {categoryId} doesn't exist in the database.");
                return NotFound();
            }

            var productEntity = mapper.Map<Product>(product);

            repository.Product.CreateProduct(categoryId, productEntity);
            await repository.SaveAsync();

            var productToReturn = mapper.Map<ProductDto>(productEntity);
            return CreatedAtRoute("GetProductById", new
            {
                categoryId,
                id = productToReturn.Id
            }, productToReturn);
        }

        [HttpPut("api/productCategory/{categoryId}/product/{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        public async Task<IActionResult> UpdateProduct(Guid categoryId, Guid id, [FromBody]
            ProductForUpdateDto product)
        {
            var productEntity = HttpContext.Items["product"] as Product;

            mapper.Map(product, productEntity);
            await repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("api/productCategory/{categoryId}/product/{id}")]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        public async Task<IActionResult> DeleteProduct(Guid categoryId, Guid id)
        {
            var product = HttpContext.Items["product"] as Product;

            repository.Product.DeleteProduct(product);
            await repository.SaveAsync();
            return NoContent();
        }

        [HttpGet("api/Search/{searchText}")]
        public async Task<ActionResult<List<Product>>> SearchProducts(string searchText)
        {
            return Ok(await repository.Product.SearchProducts(searchText, trackChanges: false));
        }
    }
}
