using AutoMapper;
using Business.Dtos.Requests.Category;
using Business.Dtos.Responses.Category;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Mapping;

public class CategoryMappingProfiles :Profile
{
    public CategoryMappingProfiles()
    {
        CreateMap<Category, CreateCategoryRequest>().ReverseMap();
        CreateMap<Category, CreatedCategoryResponse>().ReverseMap();
        
        CreateMap<Category, GetListedCategoryResponse>().ReverseMap();
        CreateMap<IPaginate<Category>, Paginate<GetListedCategoryResponse>>().ReverseMap();

        CreateMap<Category, DeleteCategoryRequest>().ReverseMap();
        CreateMap<Category, DeletedCategoryResponse>().ReverseMap();
        
        CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
        CreateMap<Category, UpdatedCategoryResponse>().ReverseMap();
    }

    
}