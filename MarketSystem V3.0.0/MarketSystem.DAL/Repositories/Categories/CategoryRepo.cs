using MarketSystem.DAL.Data.ApplicationContext;
using MarketSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.DAL.Repositories.Categories;

public class CategoryRepo : ICategoryRepo
{
    private readonly MarketSystemContext _context;
    public CategoryRepo(MarketSystemContext context)
        => _context = context;

    public async Task<IEnumerable<CategoryModel>> GetAllCategories()
           => await _context.Categories.ToListAsync();


    public async Task<CategoryModel> GetCategoryById(int id)
    {
        var Result = await _context.Categories.FirstOrDefaultAsync(i => i.Id == id);
        if (Result == null)
            return null;
        return Result;
    }
    public async Task<CategoryModel> GetCategoryByName(string Name)
    {
        var Result = await _context.Categories.FirstOrDefaultAsync(i => i.Name == Name);
        if (Result == null)
            return null;
        return Result;
    }


    public async Task AddNewCategory(CategoryModel _category)
        => await _context.Categories.AddAsync(_category);


    public async Task UpdateExistingCategory(int id,CategoryModel _category)
    {
        var Result = await GetCategoryById(id);
        Result.Name = _category.Name;
    }


    public async Task DeleteExistingCategory(int id)
    {
        var Result = await GetCategoryById(id);
        _context.Remove(Result);

    }

    public async Task SaveChanges()
      =>await _context.SaveChangesAsync();
    
    
}

