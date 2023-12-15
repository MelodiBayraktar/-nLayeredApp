using DataAccess.Abstracts;

namespace Business.Rules;

public class ProductBusinessRules
{
    private readonly IProductDal _productDal;

    public ProductBusinessRules(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public async Task MaksimumCountIsTwenty()
    {
        var result = await _productDal.GetListAsync();
        if (result.Count == 10)
        {
            throw new Exception("Kategori limiti aşıldı.");
        }
    }
}