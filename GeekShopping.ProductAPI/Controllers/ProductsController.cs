using GeekShopping.ProductAPI.DTOs;
using GeekShopping.ProductAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productRepository.FindAllProductsAsync();
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _productRepository.FindProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDTO)
    {
        var product = await _productRepository.CreateProductAsync(productDTO);
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO productDTO)
    {
        var product = await _productRepository.UpdateProductAsync(productDTO);
        return Ok(product);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await _productRepository.DeleteProductAsync(id);
        return NoContent();
    }
}