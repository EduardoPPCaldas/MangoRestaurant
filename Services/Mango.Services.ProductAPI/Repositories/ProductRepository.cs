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
    public async Task<ProductDTO> CreateProduct(ProductDTO productDTO)
    {
        var product = _mapper.Map<Product>(productDTO);
        if (product.ProductId > 0)
        {
            throw new Exception();
        }
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        try
        {
            var product = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == productId);
            if (product is null)
            {
                return false;
            }
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
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

    public async Task<ProductDTO> UpdateProduct(int id, ProductDTO productDTO)
    {
        var product = _mapper.Map<Product>(productDTO);
        var existingProduct = await _db.Products.FirstOrDefaultAsync();

        if(existingProduct is null)
        {
            throw new Exception();
        }
        if (id == 0)
        {
            throw new Exception();
        }
        _db.Update(product);
        await _db.SaveChangesAsync();
        return _mapper.Map<ProductDTO>(product);
    }
}
