using System.Collections.Generic;

namespace RecipeManager.Models
{
	public class Recipe
	{
		public int RecipeId { get; set; }
		public required string Name { get; set; } = string.Empty;
		public required string Instructions { get; set; } = string.Empty;
		public required string CookingTime { get; set; } = string.Empty;
		public int Servings { get; set; }
		// Added virtual for lazy loading support
		public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
	}
}