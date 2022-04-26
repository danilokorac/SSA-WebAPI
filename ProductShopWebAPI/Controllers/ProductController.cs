using BusinessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        IProductBusiness productBusiness;

        public ProductController(IProductBusiness productBusiness)
        {
            this.productBusiness = productBusiness;
        }

        [HttpGet("getAllProducts")]
        public List<Product> getAllProducts()
        {
            return this.productBusiness.getAllProducts();

        }

        [HttpPost("insertProduct")]
        public bool insertProduct([FromBody] Product product)
        {
            return this.productBusiness.insertProduct(product);

        }

        [HttpGet("{firstValue}/{secondValue}/get")]
        public List<Product> priceBetweenTwoValues(decimal firstValue, decimal secondValue)
        {
            return this.productBusiness.priceBetweenTwoValues(firstValue, secondValue);

        }

    }
}
