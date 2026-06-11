using MarketSystem.BLL.DTOs.Produtc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.Manager.Product
{
    public interface IProductManager
    {
        Task<IEnumerable<ProductReadAllDTO>> GetAllProducts();
        Task <ProductGetByIDDTO> GetProductById(int id);
        Task<ProducGetByTitleDTO> GetProductByTitle(string title);
        Task AddNewProduct(ProductAddDTO _product);
        Task UpdateExistingProduct(int id ,ProductUpdateDTO _product);
        Task DeleteExistingProduct(int id);
        Task SaveChanges();
    }
}
