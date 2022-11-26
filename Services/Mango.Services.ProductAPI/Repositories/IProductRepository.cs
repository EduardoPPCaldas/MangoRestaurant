using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mango.Services.ProductAPI.Models.DTOs;

namespace Mango.Services.ProductAPI.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetProductById(int productId);
    Task<ProductDTO> CreateProduct(ProductDTO productDTO);
    Task<ProductDTO> UpdateProduct(ProductDTO productDTO);
    Task<bool> DeleteProduct(int productId);
}
