using Model;
using Repository.Interface;
using Repository.MySQL;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoriesService : ICategoriesService
    {
        private ICategoriesRepository categoriesRepository = null;

        public CategoriesService()
        {
            categoriesRepository = new CategoriesRepository();
        }

        public List<Category> RetriveAllCategories()
        {
            return categoriesRepository.RetriveAllCategories();
        }
    }
}
