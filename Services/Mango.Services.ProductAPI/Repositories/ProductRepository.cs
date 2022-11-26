using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ProductRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public Task<ProductDTO> CreateProduct(ProductDTO productDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(int productId)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductDTO> GetProductById(int productId)
    {
        var product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        List<Product> products = await _db.Products.ToListAsync();
        return _mapper.Map<List<ProductDTO>>(products);
    }

    public Task<ProductDTO> UpdateProduct(ProductDTO productDTO)
    {
        throw new NotImplementedException();
    }
}
