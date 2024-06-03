namespace WebApplication10.ResponseModels;

public class PostProductModel
{
    public string ProductName { get; set; }
    public decimal ProductWeight { get; set; }
    public decimal ProductWidth { get; set; }
    public decimal ProductHeight { get; set; }
    public decimal ProductDepth { get; set; }
    public IEnumerable<int> ProductCategories { get; set; }
    
}