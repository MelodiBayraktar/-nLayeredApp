using Business.Dtos.Requests.Category;
using Business.Dtos.Responses.Category;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICategoryService
{
    Task<IPaginate<GetListedCategoryResponse>> GetListAsync();
    Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest);
    Task<DeletedCategoryResponse> Delete(DeleteCategoryRequest deleteCategoryRequest);
   
    Task<UpdatedCategoryResponse> Update(UpdateCategoryRequest updateCategoryRequest);
}