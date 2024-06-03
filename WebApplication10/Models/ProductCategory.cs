using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models;

[Table("Products_Categories")]
public class ProductCategory
{
    [Column("FK_product")]
    [ForeignKey("Products")]
    public int ProductId { get; set; }
    [Column("FK_category")]
    [ForeignKey("Categories")]
    public int CategoryId { get; set; }
    
    public Product Product { get; set; }
    
    public Category Category { get; set; }
}