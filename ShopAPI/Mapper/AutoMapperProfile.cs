using AutoMapper;
using ShopAPI.Request;
using ShopAPI.Response;
using ShopLibrary.BussinessObject;

namespace ShopAPI.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductRequest>();
            CreateMap<Product, ProductResponse>();
            CreateMap<Size, ProductSizeReponse>();

            CreateMap<ProductRequest, Product>()
           .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())  // Bỏ qua các trường không cần thiết
           .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.Now)) // Gán giá trị hiện tại
           .ForMember(dest => dest.CartItems, opt => opt.Ignore())  // Không map danh sách liên quan
           .ForMember(dest => dest.OrderItems, opt => opt.Ignore());
        }

    }
    
}
