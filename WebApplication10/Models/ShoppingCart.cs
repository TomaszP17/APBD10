using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models;

[Table("Shopping_Carts")]
public class ShoppingCart
{
    [Column("FK_account")]
    [ForeignKey("Accounts")]
    public int AccountID { get; set; }
    
    [Column("FK_product")]
    [ForeignKey("Products")]
    public int ProductID { get; set; }
    
    [Column("amount")]
    public int ShoppingCartAmount { get; set; }
    
    public Account Account { get; set; }
    
    public Product Product { get; set; }
}