using AutoMapper;
using BackEnd.DTO.ProductDTO;
using BackEnd.DTO.CategoryDTO;

namespace BackEnd.Profiles
{
    public class AllProfile : Profile
    {
        public AllProfile()
        {
            CreateMap<CreateProductDto, BackEnd.Model.Product>();
            CreateMap<ListProductDto, BackEnd.Model.Product>();
            CreateMap<ReadProductDto, BackEnd.Model.Product>();
            CreateMap<UpdateProductDto, BackEnd.Model.Product>();

            CreateMap<CategoryDto, BackEnd.Model.Category>();
        }
    }
}
