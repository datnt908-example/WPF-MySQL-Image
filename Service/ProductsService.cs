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
    public class ProductsService : IProductsService
    {
        private IProductsRepository productsRepository = null;

        public ProductsService()
        {
            productsRepository = new ProductsRepository();
        }

        public Product CreateNewProduct(Product product)
        {
            return productsRepository.CreateNewProduct(product);
        }

        public Product DeleteCurProduct(Product product)
        {
            if (productsRepository.DeleteCurProduct(product) == 1)
                return product;
            return null;
        }

        public List<Product> RetriveAllProducts()
        {
            return productsRepository.RetriveAllProducts();
        }

        public Product UpdateCurProduct(Product product)
        {
            if (productsRepository.UpdateCurProduct(product) == 1)
                return product;
            return null;
        }
    }
}
