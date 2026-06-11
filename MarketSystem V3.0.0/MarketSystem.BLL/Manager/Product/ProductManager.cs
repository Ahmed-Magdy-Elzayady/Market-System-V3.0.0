using AutoMapper;
using MarketSystem.BLL.DTOs.Produtc;
using MarketSystem.DAL.Data.Models;
using MarketSystem.DAL.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.Manager.Product
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepo _productrepository;
        private readonly IMapper _automapper;
        public ProductManager(IProductRepo productrepository, IMapper automapper)
        {
            _productrepository = productrepository;
            _automapper = automapper;
        }
        public async Task<IEnumerable<ProductReadAllDTO>> GetAllProducts()
        {
           var AllProduct= await _productrepository.GetAllProducts();
           var MapedData= _automapper.Map<IEnumerable<ProductReadAllDTO>>(AllProduct);
            return MapedData;
        }


        public async Task<ProductGetByIDDTO> GetProductById(int id)
        {

            var DataById = await _productrepository.GetProductById(id);
            var MapedData = _automapper.Map<ProductGetByIDDTO>(DataById);
            return MapedData;
        }


        public async Task<ProducGetByTitleDTO> GetProductByTitle(string title)
        {
            var DataByTitle = await _productrepository.GetByTitle(title);
            var MapedData = _automapper.Map<ProducGetByTitleDTO>(DataByTitle);
            return MapedData;
        }

        public async Task AddNewProduct(ProductAddDTO _product)
        {
           var MapedData= _automapper.Map<ProductModel>(_product);
            await _productrepository.AddNewProduct(MapedData);
        }

        public async Task UpdateExistingProduct(int id,ProductUpdateDTO _product)
        {
            var MapedData = _automapper.Map<ProductModel>(_product);
            await _productrepository.UpdateExistingProduct(id,MapedData);

        }

        public async Task DeleteExistingProduct(int id)
            =>await _productrepository.DeleteExistingProduct(id);
        
        public async Task SaveChanges()
              => await _productrepository.SaveChanges();
        
    }
}
