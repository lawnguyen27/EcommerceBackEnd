using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopAPI.Request;
using ShopLibrary.BussinessObject;
using ShopLibrary.Repository.Interface;
using ShopLibrary.Repository;
using ShopLibrary.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using ShopAPI.Mapper;
using ShopAPI.Response;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository repository = new ProductRepository();
        IProductSizeRepository productSizeRepository = new ProductSizeRepository();
        IMapper mapper;
        public ProductController(IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
          
        }
        [Authorize(Roles = "admin,customer")]
        [HttpGet("all")]
        public ActionResult<IQueryable<ProductRequest>> Get( int pageNumber,int pageSize)
        {

            var products =repository.GetProducts(pageNumber,pageSize);
            // Kiểm tra null hoặc rỗng
            if (products == null || !products.Any())
            {
                return BadRequest("No products found.");
            }

            // Kiểm tra mapper
            if (mapper == null)
            {
                throw new Exception("Mapper is not initialized.");
            }
            var productRequests = mapper.Map<List<ProductRequest>>(products);
            return Ok(productRequests);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Add([FromBody] ProductRequest productRequest)
        {
            Product product = mapper.Map<Product>(productRequest);

                  try
            {
               var p= repository.InsertProduct(product);
                
                for (int i = 1; i <= 5; i++)
                {
                    ProductSize ps = new ProductSize();
                    ps.ProductId = p.ProductId;
                    ps.SizeId = i;
                    ps.Quantity = productRequest.Quantity[i-1];
                    productSizeRepository.InsertProductSize(ps);

                }
                return Ok(productRequest);

            }
            catch
            {
                return BadRequest("Fail to add");
            }

        }
        // GET api/<UserController>/5
        [Authorize]
         [HttpGet("{id}")]
          public ActionResult Get([FromRoute] int id)
          {
             var product = repository.GetProductByID(id);

            if (product == null)
           {
                return NotFound();
            }
             return Ok(product);
         }
       // [Authorize]
        [HttpGet("sex")]

        public ActionResult<IQueryable<ProductResponse>> GetBySex(int pageNumber, int pageSize,string sex)
        {
            var products = repository.GetProductListBySex(pageNumber,pageSize,sex);

            if (products == null || !products.Any())
            {
                return BadRequest("No products found.");
            }

            // Kiểm tra mapper
            if (mapper == null)
            {
                throw new Exception("Mapper is not initialized.");
            }
            var productResponse = mapper.Map<List<ProductResponse>>(products);
            return Ok(productResponse);
        }
        // POST api/<UserController>


        // PUT api/<UserController>/5
        [Authorize(Roles = "admin")]
        [HttpPut("{key}")]
        public ActionResult Put([FromRoute] int key, [FromBody] ProductRequest productRequest)
        {
            var u = repository.GetProductByID(key);

            if (u == null)
            {
                return NotFound();
            }
            if (u != null)
            {
                u.Name = productRequest.Name;
                u.Price = productRequest.Price;
                u.Description = productRequest.Description;
                u.CategoryId = productRequest.CategoryId;
                u.ImageUrl = productRequest.ImageUrl;

                u.UpdatedAt = DateTime.Now;
            }
            repository.UpdateProduct(u);

            return Ok(u);
        }

        // DELETE api/<UserController>/5
        [Authorize(Roles = "admin")]

        [HttpDelete("{key}")]
        public ActionResult Delete([FromRoute] int key)
        {
            var p =repository.GetProductByID(key);

            if (p != null)
            {
                repository.DeleteProduct(p);
            }
            return Ok("Success");
        }
      
    }
}
