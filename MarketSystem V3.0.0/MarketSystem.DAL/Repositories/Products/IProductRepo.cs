using MarketSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.DAL.Repositories.Products;

    public interface IProductRepo
    {
        Task <IEnumerable<ProductModel>> GetAllProducts();
       Task< ProductModel >GetProductById(int id);
        Task <ProductModel> GetByTitle(string title);
        Task AddNewProduct(ProductModel _product);
        Task UpdateExistingProduct(int id,ProductModel _product);
        Task DeleteExistingProduct(int id);
        Task SaveChanges();

    }

