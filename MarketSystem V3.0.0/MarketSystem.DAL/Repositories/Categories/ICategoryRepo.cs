using MarketSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.DAL.Repositories.Categories
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<CategoryModel>> GetAllCategories();
        Task<CategoryModel> GetCategoryById(int id);
        Task<CategoryModel> GetCategoryByName(string Name);
        Task AddNewCategory(CategoryModel _category);
        Task UpdateExistingCategory(int id,CategoryModel _category);
        Task DeleteExistingCategory(int id);
        Task SaveChanges();
    }
}
