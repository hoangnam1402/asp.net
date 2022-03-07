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
            CreateMap<BackEnd.Model.Product, ReadProductDto>();
            CreateMap<UpdateProductDto, BackEnd.Model.Product>();

            CreateMap<CreateCategoryDto, BackEnd.Model.Category>();
            CreateMap<BackEnd.Model.Category, ReadCategoryDto>();
        }
    }
}
