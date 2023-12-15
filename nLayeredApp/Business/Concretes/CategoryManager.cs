using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.Category;
using Business.Dtos.Responses.Category;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class CategoryManager :ICategoryService
{
    private ICategoryDal _categoryDal;
    private IMapper _mapper;
    private CategoryBusinessRules _categoryBusinessRules;


    public CategoryManager(ICategoryDal categoryDal, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
    {
        _categoryDal = categoryDal;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<IPaginate<GetListedCategoryResponse>> GetListAsync()
    {
        var getList = await _categoryDal.GetListAsync();
        var result = _mapper.Map<Paginate<GetListedCategoryResponse>>(getList);
        return result;
    }

    public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
    {
        await _categoryBusinessRules.MaksimumCountIsTen();
        Category addCategory = _mapper.Map<Category>(createCategoryRequest);
        Category createdCategory = await _categoryDal.AddAsync(addCategory);
        return _mapper.Map<CreatedCategoryResponse>(createdCategory);
        
    }

    public async Task<DeletedCategoryResponse> Delete(DeleteCategoryRequest deleteCategoryRequest)
    {
        Category deleteCategory = await _categoryDal.GetAsync(c => c.Id == deleteCategoryRequest.Id);
        await _categoryDal.DeleteAsync(deleteCategory);
        return _mapper.Map<DeletedCategoryResponse>(deleteCategory);
    }

    public async Task<UpdatedCategoryResponse> Update(UpdateCategoryRequest updateCategoryRequest)
    {
        Category updateCategory = await _categoryDal.GetAsync(c => c.Id == updateCategoryRequest.Id);
        _mapper.Map(updateCategoryRequest, updateCategory);
        Category updatedCategory = await _categoryDal.UpdateAsync(updateCategory);
        return _mapper.Map<UpdatedCategoryResponse>(updatedCategory);

    }
}