using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, CreateProductRequest>().ReverseMap();
            CreateMap<Product, DeleteProductRequest>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
            CreateMap<Product, CreatedProductResponse>().ReverseMap();
            CreateMap<Product, UpdatedProductResponse>().ReverseMap();
            CreateMap<Product, DeletedProductResponse>().ReverseMap();

            CreateMap<Product, GetListedProductResponse>().ForMember(destinationMember: p => p.CategoryName, memberOptions: opt => opt.MapFrom(p => p.Category.Name)).ReverseMap();
            CreateMap<Paginate<Product>, Paginate<GetListedProductResponse>>().ReverseMap();
        }
    }
}
