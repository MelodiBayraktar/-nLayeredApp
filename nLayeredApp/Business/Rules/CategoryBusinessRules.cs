using DataAccess.Abstracts;

namespace Business.Rules;

public class CategoryBusinessRules
{
    private readonly ICategoryDal _categoryDal;

    public CategoryBusinessRules(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public async Task MaksimumCountIsTen()
    {
        var result = await _categoryDal.GetListAsync();
        if (result.Count == 10)
        {
            throw new Exception("Kategori limiti aşıldı.");
        }
    }
}