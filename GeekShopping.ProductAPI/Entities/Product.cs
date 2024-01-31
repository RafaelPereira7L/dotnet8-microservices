using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Entities;

public class Product : Entity
{
    [Required]
    [StringLength(150)]
    public string Name { get; set; }
    
    [Required]
    [Range(1, 10000)]
    public decimal Price { get; set; }
    
    [StringLength(255)] 
    public string? Description { get; set; }

    [StringLength(50)]
    public string? CategoryName { get; set; }

    [StringLength(255)]
    public string? ImageUrl { get; set; }
}