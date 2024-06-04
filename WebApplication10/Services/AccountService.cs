using Microsoft.EntityFrameworkCore;
using WebApplication10.Contexts;
using WebApplication10.Exceptions;
using WebApplication10.ResponseModels;

namespace WebApplication10.Services;

public class AccountService(DatabaseContext context) : IAccountService
{
    public async Task<GetAccountResponseModel> GetAccountByIdAsync(int id)
    {
        var response = await context.Accounts
            .Where(e => e.AccountId == id)
            .Select(e => new GetAccountResponseModel
            {
                FirstName = e.AccountFirstName,
                LastName = e.AccountLastName,
                Email = e.AccountEmail,
                Phone = e.AccountPhone,
                Role = e.Role.RoleName,
                Cart = e.ShoppingCarts.Select(el => new CartResponseModel
                {
                    ProductId = el.Product.ProductId,
                    ProductName = el.Product.ProductName,
                    Amount = el.ShoppingCartAmount
            }).ToList() 
            }).FirstOrDefaultAsync();
        
        if (response is null)
        {
            throw new NotFoundException($"Employee with id:{id} not found");
        }

        return response;
    }
}