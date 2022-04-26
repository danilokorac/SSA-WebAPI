using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductBusiness : IProductBusiness
    {
        IProductRepository productRepository;

        public ProductBusiness(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> getAllProducts()
        {
            List<Product> returnAllProducts = this.productRepository.getAllProducts();

            if (returnAllProducts.Count > 0)
                return returnAllProducts;
            else
                return null;
        }

        public bool insertProduct(Product product)
        {
            if (this.productRepository.insertProduct(product) > 0)
                return true;
            else
                return false;
        }

        public List<Product> priceBetweenTwoValues(decimal firstValue, decimal secondValue)
        {
            List<Product> productsToReturn = this.productRepository.getAllProducts();
            return productsToReturn.FindAll(prod => firstValue < prod.Price && secondValue > prod.Price);

        }
    }
}
