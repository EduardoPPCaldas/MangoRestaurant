using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mango.Services.ProductAPI.Models.DTOs;
using Mango.Services.ProductAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseDTO<IEnumerable<ProductDTO>>>> Get()
    {
        var response = new ResponseDTO<IEnumerable<ProductDTO>>();
        try
        {
            IEnumerable<ProductDTO> productDTOs = await _productRepository.GetProducts();
            response.Result = productDTOs;
        }
        catch(Exception ex)
        {
            response.IsSuccess = false;
            response.ErrorsMessages = new List<string>
            {
                ex.ToString()
            };
        }
        
        if(!response.IsSuccess)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseDTO<ProductDTO>>> GetById(int id)
    {
        var response = new ResponseDTO<ProductDTO>();
        try
        {
            response.Result = await _productRepository.GetProductById(id);
            if(response.Result is null)
            {
                response.IsSuccess = false;
            }
        }
        catch(Exception ex)
        {
            response.IsSuccess = false;
            response.ErrorsMessages = new List<string>
            {
                ex.ToString()
            };
        }

        if(!response.IsSuccess)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
}
