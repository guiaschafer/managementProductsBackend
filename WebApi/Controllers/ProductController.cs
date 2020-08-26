using ManagementProducts.Service.Interface.Dtos;
using ManagementProducts.Service.Interface.Updaters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementProducts.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public readonly IProductUpdater _productUpdater;
        public ProductController(IProductUpdater productUpdater)
        {
            _productUpdater = productUpdater;
        }

        /// <summary>
        ///  Adding a new product
        /// </summary>
        [HttpPost]
        public IActionResult AddProduct(ProductDto product)
        {
            try
            {
                product.Id = 0;
                _productUpdater.Save(product);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct(ProductDto product)
        {
            try
            {
                var productDb = _productUpdater.Update(product);

                if (productDb.Equals(null))
                {
                    return BadRequest("Product not found!");
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
