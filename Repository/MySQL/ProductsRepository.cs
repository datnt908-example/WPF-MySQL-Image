using Model;
using MySql.Data.MySqlClient;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MySQL
{
    public class ProductsRepository : IProductsRepository
    {
        public Product CreateNewProduct(Product product)
        {
            MySqlConnection connection = DBConnection.Instance().Connection;
            try
            {
                connection.Open();
                byte[] imageData = ProductConverter.ToBytesArray(product.BitmapImage);
                MySqlCommand command = new MySqlCommand("create_new_product", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@_title", product.Title);
                command.Parameters.AddWithValue("@_price", product.Price);
                command.Parameters.AddWithValue("@_categoryId", product.CategoryId);
                command.Parameters.AddWithValue("@_image", imageData);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product.Id = int.Parse(reader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            connection.Close();
            return product;
        }

        public int DeleteCurProduct(Product product)
        {
            MySqlConnection connection = DBConnection.Instance().Connection;
            try
            {
                connection.Open();
                byte[] imageData = ProductConverter.ToBytesArray(product.BitmapImage);
                MySqlCommand command = new MySqlCommand("delete_cur_product", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@_idproduct", product.Id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            connection.Close();
            return 1;
        }

        public List<Product> RetriveAllProducts()
        {
            List<Product> products = new List<Product>();
            MySqlConnection connection = DBConnection.Instance().Connection;
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("retrive_all_products", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    byte[] imageData = reader[4] as byte[];
                    Product product = new Product();
                    product.Id = int.Parse(reader[0].ToString());
                    product.Title = reader[1].ToString();
                    product.Price = int.Parse(reader[2].ToString());
                    product.CategoryId = int.Parse(reader[3].ToString());
                    if (imageData != null)
                        product.BitmapImage = ProductConverter.ToBitmapImage(imageData);
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            connection.Close();
            return products;
        }

        public int UpdateCurProduct(Product product)
        {
            MySqlConnection connection = DBConnection.Instance().Connection;
            try
            {
                connection.Open();
                byte[] imageData = ProductConverter.ToBytesArray(product.BitmapImage);
                MySqlCommand command = new MySqlCommand("update_cur_product", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@_idproduct", product.Id);
                command.Parameters.AddWithValue("@_title", product.Title);
                command.Parameters.AddWithValue("@_price", product.Price);
                command.Parameters.AddWithValue("@_categoryId", product.CategoryId);
                command.Parameters.AddWithValue("@_image", imageData);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            connection.Close();
            return 1;
        }
    }
}
