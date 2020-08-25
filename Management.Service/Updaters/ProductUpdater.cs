using AutoMapper;
using ManagementProducts.Service.Interface.Dtos;
using ManagementProducts.Service.Interface.Repositories;
using ManagementProducts.Service.Interface.Updaters;
using ManagementProduts.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementProducts.Service.Updaters
{
    public class ProductUpdater : IProductUpdater
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductUpdater(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void Delete(ProductDto dto)
        {
            _productRepository.SaveAtDatabase(_mapper.Map<Product>(dto));
        }

        public ProductDto Save(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            return _mapper.Map<ProductDto>(_productRepository.SaveAtDatabase(product));
        }

        public ProductDto Update(ProductDto dto)
        {
            var productDb = _productRepository.GetProductById(dto.Id);

            if (productDb.Equals(null))
            {
                return null;
            }

            productDb.Name = dto.Name;
            productDb.Price = dto.Price;
            productDb.QuantityOnStock = dto.QuantityOnStock;

            return _mapper.Map<ProductDto>(_productRepository.UpdateAtDatabase(productDb));
        }
    }
}
