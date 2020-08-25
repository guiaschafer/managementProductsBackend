using ManagementProducts.Service.Interface.Dtos;
using ManagementProduts.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ManagementProducts.Service.Interface.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
