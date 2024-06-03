using Microsoft.EntityFrameworkCore;
using WebApplication10.Contexts;
using WebApplication10.Models;
using WebApplication10.ResponseModels;

namespace WebApplication10.Services;

public class ProductService(DatabaseContext context) : IProductService
{
    public async Task<PostProductModel> CreateProduct(PostProductModel product)
    {
        var newProduct = new Product
        {
            ProductName = product.ProductName,
            ProductWeight = product.ProductWeight,
            ProductWidth = product.ProductWidth,
            ProductHeight = product.ProductHeight,
            ProductDepth = product.ProductDepth
        };
        
        var categories = await context.Categories
            .Where(e => product.ProductCategories.Contains(e.CategoryId))
            .ToListAsync();
        
        newProduct.ProductCategories = categories.Select(e => new ProductCategory
        {
            Category = e,
            Product = newProduct
        });
        
        await context.Products.AddAsync(newProduct);
        await context.ProductCategories.AddRangeAsync(newProduct.ProductCategories);
        await context.SaveChangesAsync();
        return product;
    }
}