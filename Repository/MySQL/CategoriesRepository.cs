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
    public class CategoriesRepository : ICategoriesRepository
    {
        public List<Category> RetriveAllCategories()
        {
            List<Category> categories = new List<Category>();
            MySqlConnection connection = DBConnection.Instance().Connection;
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("retrive_all_categories", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category();
                    category.Id = int.Parse(reader[0].ToString());
                    category.Title = reader[1].ToString();
                    categories.Add(category);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            connection.Close();
            return categories;
        }
    }
}
