using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Mapping;

public class ProductMappingProfiles : Profile
{
    public ProductMappingProfiles()
    {
        CreateMap<Product, CreateProductRequest>().ReverseMap();
        CreateMap<Product, CreatedProductResponse>().ReverseMap();
        
        //CreateMap<Product, GetListedProductResponse>().ReverseMap();
        
        CreateMap<Product, GetListedProductResponse>().ForMember(destinationMember: p => p.CategoryName,
            memberOptions: opt => opt.MapFrom(p => p.Category.Name)).ReverseMap();
        CreateMap<IPaginate<Product>, Paginate<GetListedProductResponse>>().ReverseMap();

        CreateMap<Product, DeleteProductRequest>().ReverseMap();
        CreateMap<Product, DeletedProductResponse>().ReverseMap();
        
        CreateMap<Product, UpdateProductRequest>().ReverseMap();
        CreateMap<Product, UpdatedProductResponse>().ReverseMap();
    }
}