using MarketSystem.BLL.DTOs.Produtc;
using MarketSystem.BLL.Manager.Category;
using MarketSystem.BLL.Manager.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MArketSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{

    private readonly ICategoryManager _categoryManager;
    public CategoryController(ICategoryManager categoryManager)
        => _categoryManager = categoryManager;

    [HttpGet]
    [Route("GetAllCategories")]
    [Authorize(Roles ="Admin,User")]
    public async Task<ActionResult> GetAllCategories ()
        => Ok(await _categoryManager.GetAllCategories());

    [HttpGet]
    [Route("{id}")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult> GetCategoryById(int id)
        => Ok(await _categoryManager.GetCategoryById(id));

    [HttpGet]
    [Route("GetByName")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult> GetCAtegoryByTitle([FromQuery] string Name)
        => Ok(await _categoryManager.GetCAtegoryByTitle(Name));


    [HttpPost]

    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> AddNewCategory(CategoryAddDto _caregory)
    {
        await _categoryManager.AddNewCategory(_caregory);
        await _categoryManager.SaveChanges();
        return Ok("Category Added Succssfully");
    }

    [HttpPut]
    [Route("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> UpdateExistingCategory(int id, CategoryUpdateDTO _category)
    {
        await _categoryManager.UpdateExistingCategory(id, _category);
        await _categoryManager.SaveChanges();
        return Ok("Category Update Successfully");
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]

    public async Task<ActionResult> DeleteExistingCategory(int id)
    {
       await _categoryManager.DeleteExistingCategory(id);
        await _categoryManager.SaveChanges();
        return Ok("Product Deleted Successfully");
    }


}

