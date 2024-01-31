using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Entities;

public class Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Timestamp]
    public DateTime CreatedAt { get; set; }
    
    [Timestamp]
    public DateTime? UpdatedAt { get; set; }
}