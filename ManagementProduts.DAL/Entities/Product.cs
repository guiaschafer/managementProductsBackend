using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementProduts.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public double Price { get; set; }
        public int QuantityOnStock { get; set; }
    }
}
