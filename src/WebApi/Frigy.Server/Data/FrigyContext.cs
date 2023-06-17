using Dumpify;

using Frigy.Server.Models;

using Microsoft.EntityFrameworkCore;

using Throw;

namespace Frigy.Server.Data;

public class FrigyContext : DbContext
{
    public const string ConnectionStringName = nameof(FrigyContext);

    public static void Configure(DbContextOptionsBuilder builder, IConfiguration configuration)
    {
        var connectionString = configuration
            .GetConnectionString(ConnectionStringName)
            .ThrowIfNull()
            .IfEmpty();

        builder.UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
    }

    public FrigyContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(FrigyContext).Assembly);
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Fridge> Fridges { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
    public DbSet<Recipe> Recipes { get; set; } = null!;
    public DbSet<RecipeCategory> RecipeCategories { get; set; } = null!;
    public DbSet<ShoppingList> ShoppingLists { get; set; } = null!;
}