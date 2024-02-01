namespace GeekShopping.WebUI.Models;

public class ProductModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public string? Description { get; set; }

    public string? CategoryName { get; set; }

    public string? ImageUrl { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}