using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class seededRecipesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "CookingTime", "Instructions", "Name", "Servings" },
                values: new object[,]
                {
                    { 1, "30 minutes", "1. Cook pasta. 2. Fry bacon. 3. Mix eggs, cheese, and pepper. 4. Combine all ingredients.", "Spaghetti Carbonara", 4 },
                    { 2, "20 minutes", "1. Prepare dough. 2. Spread tomato sauce. 3. Add mozzarella and basil. 4. Bake in hot oven.", "Classic Margherita Pizza", 2 },
                    { 3, "15 minutes", "1. Mix butter and sugars. 2. Add eggs and vanilla. 3. Combine dry ingredients. 4. Fold in chocolate chips. 5. Bake.", "Chocolate Chip Cookies", 24 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 3);
        }
    }
}
