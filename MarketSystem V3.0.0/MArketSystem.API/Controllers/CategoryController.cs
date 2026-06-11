using MarketSystem.BLL.DTOs.Produtc;
using MarketSystem.BLL.Manager.Category;
using MarketSystem.BLL.Manager.Product;
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
    public async Task<ActionResult> GetAllCategories ()
        => Ok(await _categoryManager.GetAllCategories());

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetCategoryById(int id)
        => Ok(await _categoryManager.GetCategoryById(id));

    [HttpGet]
    [Route("GetByName")]
    public async Task<ActionResult> GetCAtegoryByTitle([FromQuery] string Name)
        => Ok(await _categoryManager.GetCAtegoryByTitle(Name));


    [HttpPost]
    public async Task<ActionResult> AddNewCategory(CategoryAddDto _caregory)
    {
        await _categoryManager.AddNewCategory(_caregory);
        await _categoryManager.SaveChanges();
        return Ok("Category Added Succssfully");
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult> UpdateExistingCategory(int id, CategoryUpdateDTO _category)
    {
        await _categoryManager.UpdateExistingCategory(id, _category);
        await _categoryManager.SaveChanges();
        return Ok("Category Update Successfully");
    }



}

