using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Request;
using ShopLibrary.Repository.Interface;
using ShopLibrary.Repository;
using ShopLibrary.BussinessObject;
using AutoMapper;
using ShopAPI.Response;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        ISizeRepository repository = new SizeRepository();
        IProductSizeRepository psRepository = new ProductSizeRepository();
        [HttpGet]
        public ActionResult<IQueryable<Size>> Get()
        {
            var sizes = repository.GetSizes();
            // Kiểm tra null hoặc rỗng
            if (sizes == null || !sizes.Any())
            {
                return Ok("No sizes found.");
    }
            return Ok(sizes);
        }
        [HttpGet("id")]

        public ActionResult<IQueryable<ProductSize>> GetById(int productId, int sizeId)
        {
            var ps = psRepository.GetProductSizeById(productId,sizeId);

            if (ps == null )
            {
                return Ok("No products found.");
            }
            return Ok(ps);
        }
    }
      }
    

