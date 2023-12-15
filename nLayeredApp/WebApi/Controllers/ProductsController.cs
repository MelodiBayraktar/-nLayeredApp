using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Dtos.Requests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
         IProductService _productService;

         public ProductsController(IProductService productService)
         {
             _productService = productService;
         }

         [HttpPost("Add")]
         public async Task<IActionResult> Add([FromBody] CreateProductRequest createProductRequest)
         {
             var result = await _productService.Add(createProductRequest);
             return Ok(result);
         }

         [HttpGet("GetList")]
         public async Task<IActionResult> GetList()
         {
             var result = await _productService.GetListAsync(); 
             return Ok(result);
         }

         [HttpPost("Delete")]
         public async Task<IActionResult> Delete([FromBody] DeleteProductRequest deleteProductRequest)
         {
             var result = await _productService.Delete(deleteProductRequest);
             return Ok(result);
         }
         [HttpPost("Update")]
         public async Task<IActionResult> Update([FromBody] UpdateProductRequest updateProductRequest)
         {
             var result = await _productService.Update(updateProductRequest);
             return Ok(result);
         }
    }
}
