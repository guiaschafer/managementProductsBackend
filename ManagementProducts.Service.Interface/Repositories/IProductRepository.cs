using ManagementProduts.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementProducts.Service.Interface.Repositories
{
    public interface IProductRepository
    {
        Product SaveAtDatabase(Product product);
        Product UpdateAtDatabase(Product product);
        void DeleteAtDatabase(Product product);
        Product GetProductById(int id);
    }
}
