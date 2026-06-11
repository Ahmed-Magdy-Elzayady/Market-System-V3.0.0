using AutoMapper;
using MarketSystem.BLL.DTOs.Produtc;
using MarketSystem.DAL.Data.Models;
using MarketSystem.DAL.Repositories.Categories;
using MarketSystem.DAL.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.Manager.Category
{
    public class CategoryManager : ICategoryManager
    {

        private readonly ICategoryRepo _categoryrepository;
        private readonly IMapper _automapper;
        public CategoryManager(ICategoryRepo categpryrepository, IMapper automapper)
        {
            _categoryrepository = categpryrepository;
            _automapper = automapper;
        }

        public async Task AddNewCategory(CategoryAddDto _category)
        {
            var MapedData = _automapper.Map<CategoryModel>(_category);
            await _categoryrepository.AddNewCategory(MapedData);
        }

        public async Task DeleteExistingCategory(int id)
          => await _categoryrepository.DeleteExistingCategory(id);

        public async Task<IEnumerable<CategoryReadAllDTO>> GetAllCategories()
        {
            var AllCategories = await _categoryrepository.GetAllCategories();
            var MapedData = _automapper.Map<IEnumerable<CategoryReadAllDTO>>(AllCategories);
            return MapedData;
        }

        public async Task<CategoryGetByIDDTO> GetCategoryById(int id)
        {
            var DataById = await _categoryrepository.GetCategoryById(id);
            var MapedData = _automapper.Map<CategoryGetByIDDTO>(DataById);
            return MapedData;
        }

        public async Task<CategoryGetByTitleDTO> GetCAtegoryByTitle(string title)
        {
            var DataByTitle = await _categoryrepository.GetCategoryByName(title);
            var MapedData = _automapper.Map<CategoryGetByTitleDTO>(DataByTitle);
            return MapedData;
        }

        public async Task SaveChanges()
            => await _categoryrepository.SaveChanges();
        

        public async Task UpdateExistingCategory(int id, CategoryUpdateDTO _category)
        {
            var MapedData = _automapper.Map<CategoryModel>(_category);
            await _categoryrepository.UpdateExistingCategory(id, MapedData);
        }
    }
}
