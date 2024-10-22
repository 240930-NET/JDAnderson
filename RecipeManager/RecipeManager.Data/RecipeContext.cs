using Microsoft.EntityFrameworkCore;
using RecipeManager.Models;

namespace RecipeManager.Data;

public class RecipeContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }

    public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        // You can add any additional configuration here, such as:
        // modelBuilder.Entity<Recipe>().Property(r => r.Name).IsRequired();
    }
}