using ShopLibrary.BussinessObject;

namespace ShopAPI.Response
{
    public class ProductResponse
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;

        public string Description { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public string Price { get; set; }





    }
}
