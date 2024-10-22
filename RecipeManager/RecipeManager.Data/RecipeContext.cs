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
        base.OnModelCreating(modelBuilder);

        // Seed data for Recipes
        modelBuilder.Entity<Recipe>().HasData(
            new Recipe
            {
                RecipeId = 1,
                Name = "Spaghetti Carbonara",
                Instructions = "1. Cook pasta. 2. Fry bacon. 3. Mix eggs, cheese, and pepper. 4. Combine all ingredients.",
                CookingTime = "30 minutes",
                Servings = 4
            },
            new Recipe
            {
                RecipeId = 2,
                Name = "Classic Margherita Pizza",
                Instructions = "1. Prepare dough. 2. Spread tomato sauce. 3. Add mozzarella and basil. 4. Bake in hot oven.",
                CookingTime = "20 minutes",
                Servings = 2
            },
            new Recipe
            {
                RecipeId = 3,
                Name = "Chocolate Chip Cookies",
                Instructions = "1. Mix butter and sugars. 2. Add eggs and vanilla. 3. Combine dry ingredients. 4. Fold in chocolate chips. 5. Bake.",
                CookingTime = "15 minutes",
                Servings = 24
            }
        );
    }
}