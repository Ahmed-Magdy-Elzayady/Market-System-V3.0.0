using MarketSystem.DAL.Data.ApplicationContext;
using MarketSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.DAL.Repositories.Products;

    public class ProductRepo : IProductRepo
    {
        private readonly MarketSystemContext _context;
        public ProductRepo(MarketSystemContext context)
                    => _context = context;
        

        public async Task< IEnumerable<ProductModel>> GetAllProducts()
            =>await _context.Products.AsNoTracking().Include(o => o.Category).ToListAsync();

        public async Task<ProductModel> GetProductById(int id)
        {

          var Result=  await _context.Products.Include(o => o.Category).FirstOrDefaultAsync(o => o.Id == id);
            if (Result == null)
                return null;
            return Result;
        }


        public async Task AddNewProduct(ProductModel _product)
             =>  await _context.Products.AddAsync(_product);
        

        public async Task UpdateExistingProduct(int id,ProductModel _product)
        {
            var Result = await GetProductById(id);

            Result.Title = _product.Title;
            Result.Description = _product.Description;
            Result.Price = _product.Price;
            Result.UnitOFStock = _product.UnitOFStock;
            Result.CategoryModelId = _product.CategoryModelId;
         
        }
        public async Task <ProductModel> GetByTitle(string title)
        {
            var Result = await _context.Products.Include(i=>i.Category).FirstOrDefaultAsync(i => i.Title.ToLower() == title.ToLower());
            if (Result == null)
                return null;
            return Result;
        }
        public async Task DeleteExistingProduct(int id)
        {
            var Result=await GetProductById(id);
            _context.Remove(Result);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    
     
    }

