using MarketSystem.BLL.DTOs.Produtc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.Manager.Category
{
    public interface ICategoryManager
    {

        Task<IEnumerable<CategoryReadAllDTO>> GetAllCategories();
        Task<CategoryGetByIDDTO> GetCategoryById(int id);
        Task<CategoryGetByTitleDTO> GetCAtegoryByTitle(string title);
        Task AddNewCategory(CategoryAddDto _category);
        Task UpdateExistingCategory(int id, CategoryUpdateDTO _category);
        Task DeleteExistingCategory(int id);
        Task SaveChanges();
    }
}
