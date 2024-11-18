﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeManager.Data;

#nullable disable

namespace RecipeManager.Data.Migrations
{
    [DbContext(typeof(RecipeContext))]
    [Migration("20241117053858_Validation")]
    partial class Validation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecipeManager.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            IngredientId = 1,
                            Name = "Noodles",
                            Quantity = "400g",
                            RecipeId = 1
                        },
                        new
                        {
                            IngredientId = 2,
                            Name = "Bacon",
                            Quantity = "200g",
                            RecipeId = 1
                        },
                        new
                        {
                            IngredientId = 3,
                            Name = "Eggs",
                            Quantity = "4",
                            RecipeId = 1
                        },
                        new
                        {
                            IngredientId = 4,
                            Name = "Parmesan cheese",
                            Quantity = "100g",
                            RecipeId = 1
                        },
                        new
                        {
                            IngredientId = 5,
                            Name = "Pizza dough",
                            Quantity = "1",
                            RecipeId = 2
                        },
                        new
                        {
                            IngredientId = 6,
                            Name = "Tomato sauce",
                            Quantity = "200g",
                            RecipeId = 2
                        },
                        new
                        {
                            IngredientId = 7,
                            Name = "Fresh mozzarella",
                            Quantity = "200g",
                            RecipeId = 2
                        },
                        new
                        {
                            IngredientId = 8,
                            Name = "Fresh basil leaves",
                            Quantity = "10-12",
                            RecipeId = 2
                        },
                        new
                        {
                            IngredientId = 9,
                            Name = "Flour",
                            Quantity = "280g",
                            RecipeId = 3
                        },
                        new
                        {
                            IngredientId = 10,
                            Name = "Butter",
                            Quantity = "230g",
                            RecipeId = 3
                        },
                        new
                        {
                            IngredientId = 11,
                            Name = "Brown sugar",
                            Quantity = "200g",
                            RecipeId = 3
                        },
                        new
                        {
                            IngredientId = 12,
                            Name = "White sugar",
                            Quantity = "100g",
                            RecipeId = 3
                        },
                        new
                        {
                            IngredientId = 13,
                            Name = "Eggs",
                            Quantity = "2",
                            RecipeId = 3
                        },
                        new
                        {
                            IngredientId = 14,
                            Name = "Vanilla extract",
                            Quantity = "1 tsp",
                            RecipeId = 3
                        },
                        new
                        {
                            IngredientId = 15,
                            Name = "Chocolate chips",
                            Quantity = "300g",
                            RecipeId = 3
                        });
                });

            modelBuilder.Entity("RecipeManager.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeId"));

                    b.Property<string>("CookingTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Servings")
                        .HasColumnType("int");

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            RecipeId = 1,
                            CookingTime = "30 minutes",
                            Instructions = "1. Cook pasta. 2. Fry bacon. 3. Mix eggs, cheese, and pepper. 4. Combine all ingredients.",
                            Name = "Spaghetti Carbonara",
                            Servings = 4
                        },
                        new
                        {
                            RecipeId = 2,
                            CookingTime = "20 minutes",
                            Instructions = "1. Prepare dough. 2. Spread tomato sauce. 3. Add mozzarella and basil. 4. Bake in hot oven.",
                            Name = "Classic Margherita Pizza",
                            Servings = 2
                        },
                        new
                        {
                            RecipeId = 3,
                            CookingTime = "15 minutes",
                            Instructions = "1. Mix butter and sugars. 2. Add eggs and vanilla. 3. Combine dry ingredients. 4. Fold in chocolate chips. 5. Bake.",
                            Name = "Chocolate Chip Cookies",
                            Servings = 24
                        });
                });

            modelBuilder.Entity("RecipeManager.Models.Ingredient", b =>
                {
                    b.HasOne("RecipeManager.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeManager.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
