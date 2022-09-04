using System;
using System.Collections.Generic;
using AutoMapper;
using StoreProject.Core.Domain.Products;
using StoreProject.Core.Domain.Products.Dtos;

namespace StoreProject.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategoryForCreationDto, ProductCategory>();
            CreateMap<ProductCategoryForUpdateDto, ProductCategory>();
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductCIdDto>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto, Product>();
        }
    }
}
