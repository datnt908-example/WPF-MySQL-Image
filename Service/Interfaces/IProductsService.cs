using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IProductsService
    {
        List<Product> RetriveAllProducts();
        Product CreateNewProduct(Product product);
        Product UpdateCurProduct(Product product);
        Product DeleteCurProduct(Product product);
    }
}
