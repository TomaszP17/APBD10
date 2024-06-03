using WebApplication10.ResponseModels;

namespace WebApplication10.Services;

public interface IProductService
{
    Task<PostProductModel> CreateProduct(PostProductModel product);
}