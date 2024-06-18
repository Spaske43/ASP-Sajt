using EcommerceShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.DataAccess;
public class DatabaseContext : DbContext
{
    private readonly string _connectionString;
    public DatabaseContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DatabaseContext()
    {
        _connectionString = "";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
        optionsBuilder.UseLazyLoadingProxies();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        modelBuilder.Entity<DiscountBrand>().HasKey(x => new { x.BrandId, x.DiscountId });

        modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

        foreach (EntityEntry entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                if (entry.Entity is Entity e)
                {
                    e.CreatedAt = DateTime.UtcNow;
                }
            }

            if (entry.State == EntityState.Modified)
            {
                if (entry.Entity is Entity e)
                {
                    e.UpdatedAt = DateTime.UtcNow;
                }
            }
        }

        return base.SaveChanges();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<DiscountBrand> DiscountBrands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems {  get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Discount> Discounts { get; set; }  
    public DbSet<UseCaseLog> UseCaseLogs { get; set; }
    public DbSet<UserUseCase> UserUseCases { get; set; }
}
