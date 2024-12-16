using ShopLibrary.BussinessObject;

namespace ShopAPI.Request
{
    public class ProductRequest
    {

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? Sex { get; set; }

        public int CategoryId { get; set; }

        public string ImageUrl { get; set; }
        public int[] Quantity { get; set; }




    }
}
