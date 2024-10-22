
using Microsoft.EntityFrameworkCore;
using RecipeManager.Data;
using RecipeManager.Models;
using RecipeManager.Tests;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure our DbContext and Repos here 
string connectionString = builder.Configuration["ConnectionString"]!;
builder.Services.AddDbContext<RecipeContext>(options => options.UseSqlServer(connectionString));

// set up dependency lifecycles here 
builder.Services.AddScoped<IRecipeRepo, RecipeRepo>(); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
