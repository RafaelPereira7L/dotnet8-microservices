using AutoMapper;
using GeekShopping.ProductAPI.Contexts;
using GeekShopping.ProductAPI.DTOs;
using GeekShopping.ProductAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public ProductRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProductDTO>> FindAllProductsAsync()
    {
        var products = await _context.Products.ToListAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO?> FindProductByIdAsync(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO?> FindProductByNameAsync(string name)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<IEnumerable<ProductDTO>> FindProductsByCategoryAsync(string categoryName)
    {
        var products = await _context.Products.Where(p => p.CategoryName == categoryName).ToListAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO?> CreateProductAsync(ProductDTO product)
    {
        var productEntity = _mapper.Map<Entities.Product>(product);
        await _context.Products.AddAsync(productEntity);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task<ProductDTO?> UpdateProductAsync(ProductDTO product)
    {
        var existingProduct = await _context.Products.FindAsync(product.Id);
        if (existingProduct == null)
        {
            return null;
        }
        
        existingProduct.UpdatedAt = DateTime.UtcNow;
        
        _mapper.Map(product, existingProduct);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductDTO>(existingProduct);
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return false;
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}