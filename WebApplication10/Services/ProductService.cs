using Microsoft.EntityFrameworkCore;
using WebApplication10.Contexts;
using WebApplication10.Exceptions;
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
        await context.Products.AddAsync(newProduct);
        await context.SaveChangesAsync();

        foreach (var categoryId in product.ProductCategories)
        {
            var responseCategory = await context.Categories.FindAsync(categoryId);
            if (responseCategory is null)
            {
                throw new NotFoundCategoryException($"category with that exception is not found: {categoryId}");
            }

            await context.ProductCategories.AddAsync(new ProductCategory()
            {
                ProductId = newProduct.ProductId,
                CategoryId = categoryId
            });
        }

        await context.SaveChangesAsync();
        
        return product;
    }
}