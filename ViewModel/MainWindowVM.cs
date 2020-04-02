using Model;
using Service;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class MainWindowVM
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        private IProductsService productsService = null;
        private ICategoriesService categoriesService = null;

        public ICommand CreateProduct { get; set; }
        public ICommand UpdateProduct { get; set; }
        public ICommand DeleteProduct { get; set; }

        public MainWindowVM()
        {
            // Dependency Injection
            productsService = new ProductsService();
            categoriesService = new CategoriesService();

            Products = new ObservableCollection<Product>();
            productsService.RetriveAllProducts().ForEach(Products.Add);
            Categories = new ObservableCollection<Category>();
            categoriesService.RetriveAllCategories().ForEach(Categories.Add);

            CreateProduct = new RelayCommand<Product>(
                param => param != null,
                param => CreateNewProduct(param));
            UpdateProduct = new RelayCommand<Product>(
                param => param != null,
                param => UpdateCurProduct(param));
            DeleteProduct = new RelayCommand<Product>(
                param => param != null,
                param => DeleteCurProduct(param));
        }

        private void CreateNewProduct(Product product)
        {
            Product newProduct = productsService.CreateNewProduct(product);
            if (newProduct != null)
                Products.Add(newProduct);
        }

        private void UpdateCurProduct(Product product)
        {
            Product newProduct = productsService.UpdateCurProduct(product);
            if (newProduct != null)
            {
                int index = Products.IndexOf(Products.Where(item => item.Id == newProduct.Id).Single());
                Products.RemoveAt(index);
                Products.Insert(index, newProduct);
            }
        }

        private void DeleteCurProduct(Product product)
        {
            Product delProduct = productsService.DeleteCurProduct(product);
            if (delProduct != null)
                Products.Remove(product);
        }
    }
}
