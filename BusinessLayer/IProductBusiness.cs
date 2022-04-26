using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IProductBusiness
    {
        List<Product> getAllProducts();
        bool insertProduct(Product product);
        List<Product> priceBetweenTwoValues(decimal firstValue, decimal secondValue);
    }
}
