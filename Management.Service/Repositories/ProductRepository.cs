using ManagementProducts.Service.Interface.Repositories;
using ManagementProduts.DAL.Context;
using ManagementProduts.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementProducts.Service.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly DatabaseContext _context;
        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void DeleteAtDatabase(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product SaveAtDatabase(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();

            return product;
        }

        public Product UpdateAtDatabase(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();

            return product;
        }
    }
}
