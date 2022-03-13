using AutoMapper;
using BackEnd.DTO.ProductDTO;
using BackEnd.DTO.CategoryDTO;
using BackEnd.DTO.CustomerDTO;
using BackEnd.DTO.OrderDTO;
using BackEnd.DTO.ProductRatingDTO;

namespace BackEnd.Profiles
{
    public class AllProfile : Profile
    {
        public AllProfile()
        {
            //Product
            CreateMap<CreateProductDto, BackEnd.Model.Product>(memberList: AutoMapper.MemberList.None);
            CreateMap<BackEnd.Model.Product, ReadProductDto>(memberList: AutoMapper.MemberList.None);
            CreateMap<UpdateProductDto, BackEnd.Model.Product>();

            //Category
            CreateMap<CreateCategoryDto, BackEnd.Model.Category>(memberList: AutoMapper.MemberList.None);
            CreateMap<BackEnd.Model.Category, ReadCategoryDto>(memberList: AutoMapper.MemberList.None);

            //Customer
            CreateMap<CreateCustomerDto, BackEnd.Model.Customer>(memberList: AutoMapper.MemberList.None);
            CreateMap<BackEnd.Model.Customer, ReadCustomerDto>(memberList: AutoMapper.MemberList.None);

            //Order
            CreateMap<CreateOrderDto, BackEnd.Model.Order>(memberList: AutoMapper.MemberList.None);
            CreateMap<BackEnd.Model.Order, ReadOrderDto>(memberList: AutoMapper.MemberList.None);

            //OrderItem
            CreateMap<CreateOrderItemDto, BackEnd.Model.OrderItem>(memberList: AutoMapper.MemberList.None);
            CreateMap<BackEnd.Model.OrderItem, ReadOrderItemDto>(memberList: AutoMapper.MemberList.None);

            //ProductRating
            CreateMap<CreateProductRatingDto, BackEnd.Model.ProductRating>(memberList: AutoMapper.MemberList.None);
            CreateMap<BackEnd.Model.ProductRating, ReadProductRatingDto>(memberList: AutoMapper.MemberList.None);
        }
    }
}
