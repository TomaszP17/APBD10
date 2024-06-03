using WebApplication10.ResponseModels;

namespace WebApplication10.Services;

public interface IDbService
{
    Task<GetAccountResponseModel> GetAccountByIdAsync(int id);
}