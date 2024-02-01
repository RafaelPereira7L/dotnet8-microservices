using GeekShopping.WebUI.Models;

namespace GeekShopping.WebUI.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> GetProducts();
    Task<ProductModel> GetProductById(Guid id);
    Task<ProductModel> CreateProduct(ProductModel product);
    Task<ProductModel> UpdateProduct(ProductModel product);
    Task<bool> DeleteProduct(Guid id);
}