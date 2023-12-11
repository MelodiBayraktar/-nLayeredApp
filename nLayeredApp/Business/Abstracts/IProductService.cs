using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Abstracts;

public interface IProductService
{ 
   Task<IPaginate<GetListedProductResponse>> GetListAsync();
   Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest);
}