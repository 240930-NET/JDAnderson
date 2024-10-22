namespace RecipeManager.Data;
using Microsoft.EntityFrameworkCore; 
using RecipeManager.Models; 
public class RecipeContext : DbContext
{
    public virtual DbSet<Recipe> Recipes {get; set;}


    // set up constructor 
    public RecipeContext() : base() { }

    // for connection string 
    public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
    {

    }
}
