using WebApplication10.ResponseModels;

namespace WebApplication10.Services;

public interface IAccountService
{
    Task<GetAccountResponseModel> GetAccountByIdAsync(int id);
}