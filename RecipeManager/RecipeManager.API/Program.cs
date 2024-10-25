using Microsoft.EntityFrameworkCore;
using RecipeManager.Data;
using RecipeManager.Models;
using RecipeManager.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure our DbContext and Repos here 
string connectionString = builder.Configuration.GetConnectionString("recipesStored")!;
builder.Services.AddDbContext<RecipeContext>(options => options.UseSqlServer(connectionString));

// set up dependency lifecycles here 
builder.Services.AddScoped<IRecipeRepo, RecipeRepo>(); 
builder.Services.AddScoped<IRecipeService, RecipeService>();

// Register AutoMapper in the dependency injection 
builder.Services.AddAutoMapper(typeof(MappingProfile)); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RecipeManager API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();