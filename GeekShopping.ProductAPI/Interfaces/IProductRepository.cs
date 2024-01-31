using GeekShopping.ProductAPI.DTOs;

namespace GeekShopping.ProductAPI.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<ProductDTO>> FindAllProductsAsync();
    Task<ProductDTO?> FindProductByIdAsync(Guid id);
    Task<ProductDTO?> FindProductByNameAsync(string name);
    Task<IEnumerable<ProductDTO>> FindProductsByCategoryAsync(string categoryName);
    Task<ProductDTO?> CreateProductAsync(ProductDTO product);
    Task<ProductDTO?> UpdateProductAsync(ProductDTO product);
    Task<bool> DeleteProductAsync(Guid id);
}