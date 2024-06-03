using Microsoft.EntityFrameworkCore;
using WebApplication10.Models;

namespace WebApplication10.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });
        
        modelBuilder.Entity<ShoppingCart>()
            .HasKey(sc => new { sc.AccountID, sc.ProductID });


        modelBuilder.Entity<Role>().HasData(new List<Role>()
        {
            new Role()
            {
                RoleId = 1,
                RoleName = "Admin"
            },
            new Role()
            {
                RoleId = 2,
                RoleName = "User"
            },
            new Role()
            {
                RoleId = 3,
                RoleName = "Guest"
            }
        });
        
        modelBuilder.Entity<Category>().HasData(new List<Category>()
        {
            new Category()
            {
                CategoryId = 1,
                CategoryName = "Electronics"
            },
            new Category()
            {
                CategoryId = 2,
                CategoryName = "Clothing"
            },
            new Category()
            {
                CategoryId = 3,
                CategoryName = "Books"
            }
        });
        
        modelBuilder.Entity<Product>().HasData(new List<Product>()
        {
            new Product()
            {
                ProductId = 1,
                ProductName = "Laptop",
                ProductWidth = 15.6m,
                ProductHeight = 1.5m,
                ProductDepth = 10.5m
            },
            new Product()
            {
                ProductId = 2,
                ProductName = "T-Shirt",
                ProductWidth = 0.5m,
                ProductHeight = 0.5m,
                ProductDepth = 0.5m
            },
            new Product()
            {
                ProductId = 3,
                ProductName = "Book",
                ProductWidth = 1.5m,
                ProductHeight = 1.5m,
                ProductDepth = 1.5m
            }
        });
        
        modelBuilder.Entity<ProductCategory>().HasData(new List<ProductCategory>()
        {
            new ProductCategory()
            {
                ProductId = 1,
                CategoryId = 1
            },
            new ProductCategory()
            {
                ProductId = 2,
                CategoryId = 2
            },
            new ProductCategory()
            {
                ProductId = 3,
                CategoryId = 3
            }
        });

        modelBuilder.Entity<Account>().HasData(new List<Account>()
        {
            new Account()
            {
                AccountId = 1,
                RoleId = 1,
                AccountFirstName = "Adam",
                AccountLastName = "Smyk",
                AccountEmail = "adminek@gmail.com",
                AccountPhone = "123456789"
            },
            new Account()
            {
                AccountId = 2,
                RoleId = 2,
                AccountFirstName = "John",
                AccountLastName = "Snow",
                AccountEmail = "john@derby.pl",
                AccountPhone = "987654321",
            },
            new Account()
            {
                AccountId = 3,
                RoleId = 3,
                AccountFirstName = "Mariusz",
                AccountLastName = "Pudzianowski",
                AccountEmail = "pudzian@wp.pl",
                AccountPhone = "666999666"
            }
        });
        modelBuilder.Entity<ShoppingCart>().HasData(new List<ShoppingCart>()
        {
            new ShoppingCart()
            {
                AccountID = 1,
                ProductID = 1,
                ShoppingCartAmount = 1
            },
            new ShoppingCart()
            {
                AccountID = 2,
                ProductID = 2,
                ShoppingCartAmount = 2
            },
            new ShoppingCart()
            {
                AccountID = 3,
                ProductID = 3,
                ShoppingCartAmount = 3
            }
        });
    }
}