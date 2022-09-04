using AutoMapper;
using StoreProject.API.ActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreProject.Core.Domain.Base;
using StoreProject.Core.Domain.Logger;
using StoreProject.Core.Domain.Products.Dtos;
using StoreProject.Core.Domain.Products;
using Microsoft.AspNetCore.Authorization;

namespace StoreProject.API.Controllers
{
    //[Route("api/productCategory")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IRepositoryManager repository;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;

        public ProductCategoryController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }


        [HttpGet("api/productCategory", Name = "GetAllCategories")]
        public async Task<IActionResult> GetAllProductCategories()
        {
            var categories = await repository.ProductCategory.GetAllProductCategories(trackChanges: false);
            var categoriesDto = mapper.Map<IEnumerable<ProductCategoryDto>>(categories);

            return Ok(categoriesDto);
        }

        [HttpGet("api/productCategoryAdmin")]
        public async Task<IActionResult> GetAllProductCategoriesForAdmin()
        {
            var categories = await repository.ProductCategory.GetAllProductCategoriesForAdmin(trackChanges: false);
            var categoriesDto = mapper.Map<IEnumerable<ProductCategoryDto>>(categories);

            return Ok(categoriesDto);
        }

        [HttpGet("api/productCategory/{id}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await repository.ProductCategory.GetProductCategoryById(id, trackChanges: false);
            if (category == null)
            {
                logger.LogInfo($"Category with id {id} doesn't exist in the database.");
                return NotFound();
            }

            else
            {
                var categoryDto = mapper.Map<ProductCategoryDto>(category);
                return Ok(categoryDto);
            }
        }

        [HttpPost("api/productCategory")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProductCategory([FromBody] ProductCategoryForCreationDto category)
        {
            var categoryEntity = mapper.Map<ProductCategory>(category);
            repository.ProductCategory.CreateProductCategory(categoryEntity);
            await repository.SaveAsync();

            var categoryToReturn = mapper.Map<ProductCategoryDto>(categoryEntity);
            return CreatedAtRoute("CategoryById", new { id = categoryToReturn.Id },
                categoryToReturn);

        }

        [HttpDelete("api/productCategory/{id}")]
        [ServiceFilter(typeof(ValidateProductCategoryExistsAttribute))]
        public async Task<IActionResult> DeleteProductCategory(Guid id)
        {
            var category = HttpContext.Items["category"] as ProductCategory;

            repository.ProductCategory.DeleteProductCategory(category);
            await repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("api/productCategory/{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateProductCategoryExistsAttribute))]
        public async Task<IActionResult> UpdateProductCategory(Guid id, [FromBody] ProductCategoryForUpdateDto category)
        {
            var categoryEntity = HttpContext.Items["category"] as ProductCategory;

            mapper.Map(category, categoryEntity);
            await repository.SaveAsync();
            return NoContent();
        }

    }
}
