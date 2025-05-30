namespace ProductCatalogAPI.Features.Products.Common.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {


            CreateMap<Product, GetAllProductsDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
