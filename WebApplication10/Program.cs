using Microsoft.EntityFrameworkCore;
using WebApplication10.Contexts;
using WebApplication10.Exceptions;
using WebApplication10.ResponseModels;
using WebApplication10.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IProductService, ProductService>();
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


app.MapGet("api/accounts/{id:int}", async ( int id, IDbService dbService) =>
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
app.MapPost("api/products", async (PostProductModel product, IProductService productService) =>
{
    return Results.Created("api/products", await productService.CreateProduct(product));
}).Produces<PostProductModel>();

app.UseHttpsRedirection();

app.Run();
