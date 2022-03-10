using AutoMapper;
using BackEnd.DTO.ProductDTO;
using BackEnd.DTO.CategoryDTO;
using BackEnd.DTO.CustomerDTO;

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

            CreateMap<CreateCustomerDto, BackEnd.Model.Customer>();
            CreateMap<BackEnd.Model.Customer, ReadCustomerDto>();
            CreateMap<UpdateCustomerDto, BackEnd.Model.Customer>();
        }
    }
}
