using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopLibrary.Repository.Interface;
using ShopLibrary.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ShopAPI.Request;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryRepository repository = new CategoryRepository();
        [HttpGet]
        public ActionResult<IQueryable<CategoryRequest>> Get()
        {
            var categories = repository.GetCategories();
            // Kiểm tra null hoặc rỗng
            if (categories == null || !categories.Any())
            {
                return BadRequest("No categories found.");
            }     
            return Ok(categories);
        }

    }
}
