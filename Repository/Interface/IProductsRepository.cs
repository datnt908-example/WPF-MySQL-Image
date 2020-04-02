using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IProductsRepository
    {
        List<Product> RetriveAllProducts();
        Product CreateNewProduct(Product product);
        int UpdateCurProduct(Product product);
        int DeleteCurProduct(Product product);
    }
}
