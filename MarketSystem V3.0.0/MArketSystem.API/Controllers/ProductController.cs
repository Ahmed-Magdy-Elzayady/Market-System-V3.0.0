using MarketSystem.BLL.DTOs.Produtc;
using MarketSystem.BLL.Manager.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MArketSystem.API.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
            => _productManager = productManager;

        [HttpGet]
        [Route("GetAllProducts")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult> GetAllProducts()
            => Ok(await _productManager.GetAllProducts());

        [HttpGet]
        [Route("{id}")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult> GetProductById(int id)
            => Ok(await _productManager.GetProductById(id));

    [HttpGet]
    [Route("GetByTitle")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult> GetProductByTitle([FromQuery] string Title)
        => Ok(await _productManager.GetProductByTitle(Title));

        
        [HttpPost]
         [Authorize(Roles ="Admin")]
        public async Task<ActionResult> AddNewProduct(ProductAddDTO _product)
        {
            await _productManager.AddNewProduct(_product);
            await _productManager.SaveChanges();
            return Ok("Product Added Succssfully");
        }

    [HttpPut]
    [Route("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> UpdateExistingProduct(int id, ProductUpdateDTO _product)
        {
            await _productManager.UpdateExistingProduct(id, _product);
            await _productManager.SaveChanges();
            return Ok("Produc Update Successfully");
        }


    [HttpDelete]
    [Route("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteExistingProduct(int id)
    {
        await _productManager.DeleteExistingProduct(id);
       await _productManager.SaveChanges();
        return Ok("Product Deleted Successfully");
    }




    }

