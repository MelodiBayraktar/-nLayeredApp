using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ProductManager:IProductService
{
    private IProductDal _productDal;
    private IMapper _mapper;
    private ProductBusinessRules _productBusinessRules;
    
    public ProductManager(IProductDal productDal, IMapper mapper, ProductBusinessRules productBusinessRules)
    {
        _productDal = productDal;
        _mapper = mapper;
        _productBusinessRules = productBusinessRules;
    }

    public async Task<IPaginate<GetListedProductResponse>> GetListAsync()
    {
        // //paginate içinde product listesi
        // var result = await _productDal.GetListAsync();
        //
        // //getListedProductResponse 
        // List<GetListedProductResponse> getList = new List<GetListedProductResponse>();
        //
        // //product list mapping
        // foreach (var item in result.Items)
        // {
        //     GetListedProductResponse getListedProductResponse = new GetListedProductResponse();
        //     getListedProductResponse.Id = item.Id;
        //     getListedProductResponse.ProductName = item.ProductName;
        //     getListedProductResponse.UnitPrice = item.UnitPrice;
        //     getListedProductResponse.QuantityPerUnit = item.QuantityPerUnit;
        //     getListedProductResponse.UnitsInStock = item.UnitsInStock;
        //     getList.Add(getListedProductResponse);
        // }
        //
        // //paginate mapping
        // IPaginate<GetListedProductResponse> _paginate = new IPaginate<GetListedProductResponse>();
        // _paginate.Pages = result.Pages;
        // _paginate.Items = getList;
        // _paginate.Index = result.Index;
        // _paginate.Size = result.Size;
        // _paginate.Count = result.Count;
        // _paginate.From = result.From;
        // //_paginate.HasNext=result.Result.HasNext; //auto value
        // //_paginate.HasPrevious = result.Result.HasPrevious; //auto value
        // return _paginate;
        
        var data = await _productDal.GetListAsync(
            include: p=>p.Include(p=>p.Category)
            );
        var result = _mapper.Map<Paginate<GetListedProductResponse>>(data);
        return result;

    }
    

    public async Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest)
    {
        await _productBusinessRules.MaximumCountIsTwenty(createProductRequest.CategoryId);
       //  Product product = new Product();
       //  product.Id = Guid.NewGuid();
       //  product.ProductName = createProductRequest.ProductName;
       //  product.UnitPrice = createProductRequest.UnitPrice;
       //  product.QuantityPerUnit = createProductRequest.QuantityPerUnit;
       //  product.UnitsInStock = createProductRequest.UnitsInStock;
       //  
       // Product createdProduct= await _productDal.AddAsync(product);
       //
       // CreatedProductResponse createdProductResponse = new CreatedProductResponse();
       // createdProductResponse.Id = createdProduct.Id;
       // createdProductResponse.ProductName = createProductRequest.ProductName;
       // createdProductResponse.UnitPrice = createProductRequest.UnitPrice;
       // createdProductResponse.QuantityPerUnit = createProductRequest.QuantityPerUnit;
       // createdProductResponse.UnitsInStock = createProductRequest.UnitsInStock;
       //
       // return createdProductResponse;
       
       Product product = _mapper.Map<Product>(createProductRequest);
       Product createdProduct = await _productDal.AddAsync(product);
       CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(createdProduct);
       return createdProductResponse;
       
    }

    public async Task<DeletedProductResponse> Delete(DeleteProductRequest deleteProductRequest)
    {
        Product deleteProduct = await _productDal.GetAsync(p => p.Id == deleteProductRequest.Id);
        await _productDal.DeleteAsync(deleteProduct);
        return _mapper.Map<DeletedProductResponse>(deleteProduct);
    }

    public async Task<UpdatedProductResponse> Update(UpdateProductRequest updateProductRequest)
    {
        Product updateProduct = await _productDal.GetAsync(p => p.Id == updateProductRequest.Id);
        _mapper.Map(updateProductRequest, updateProduct);
        Product updatedProduct = await _productDal.UpdateAsync(updateProduct);
        return _mapper.Map<UpdatedProductResponse>(updatedProduct);
    }
}