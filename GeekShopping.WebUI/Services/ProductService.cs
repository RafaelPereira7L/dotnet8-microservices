using GeekShopping.WebUI.Interfaces;
using GeekShopping.WebUI.Models;
using GeekShopping.WebUI.Utils;

namespace GeekShopping.WebUI.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    public const string BaseUrl = "api/v1/products";

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<IEnumerable<ProductModel>> GetProducts()
    {
        var response = await _httpClient.GetAsync(BaseUrl);
        return await response.GetAsync<IEnumerable<ProductModel>>();
    }

    public async Task<ProductModel> GetProductById(Guid id)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
        return await response.GetAsync<ProductModel>();
    }

    public async Task<ProductModel> CreateProduct(ProductModel product)
    {
        var response = await _httpClient.PostAsync(BaseUrl, product);
        
        if(!response.IsSuccessStatusCode)
        {
            throw new Exception("Error while creating product");
        }
        
        return await response.GetAsync<ProductModel>();
    }

    public async Task<ProductModel> UpdateProduct(ProductModel product)
    {
        var response = await _httpClient.PutAsJson(BaseUrl, product);

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception("Error while updating product");
        }
        
        return await response.GetAsync<ProductModel>();
    }

    public async Task<bool> DeleteProduct(Guid id)
    {
        var response = await _httpClient.Delete($"{BaseUrl}/{id}");
        
        if(!response.IsSuccessStatusCode)
        {
            throw new Exception("Error while deleting product");
        }
        
        return true;
    }
}