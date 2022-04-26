using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> getAllProducts()
        {
            List<Product> returnAllProducts = new List<Product>();

            using(SqlConnection conn = new SqlConnection(Constants.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM Products";
                SqlDataReader dR = command.ExecuteReader();
                while(dR.Read())
                {
                    Product pr = new Product();
                    pr.ID = dR.GetInt32(0);
                    pr.Name = dR.GetString(1);
                    pr.Description = dR.GetString(2);
                    pr.Price = dR.GetDecimal(3);

                    returnAllProducts.Add(pr);
                }

            }

            return returnAllProducts;
        }

        public int insertProduct(Product product)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(Constants.connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = String.Format("INSERT INTO Products VALUES('{0}','{1}','{2}')", product.Name, product.Description, product.Price);

               result = command.ExecuteNonQuery();
            }

            return result;
        }
    }
}
