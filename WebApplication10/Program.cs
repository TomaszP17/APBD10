using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApplication10.Contexts;
using WebApplication10.Exceptions;
using WebApplication10.ResponseModels;
using WebApplication10.Services;
using WebApplication10.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddValidatorsFromAssemblyContaining<AddProductValidator>();
builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("api/accounts/{id:int}", async ( int id, IAccountService dbService) =>
{
    try
    {
        return Results.Ok(await dbService.GetAccountByIdAsync(id));
    }
    catch (NotFoundException e)
    {
        return Results.NotFound(e.Message);
    }
});
app.MapPost("api/products", async (PostProductModel product, IProductService productService, IValidator<PostProductModel> validator) =>
{
    var validate = await validator.ValidateAsync(product);
    if (!validate.IsValid)
    {
        return Results.BadRequest(validate.Errors);
    }
    
    
    return Results.Created("api/products", await productService.CreateProduct(product));
}).Produces<PostProductModel>();

app.UseHttpsRedirection();

app.Run();
