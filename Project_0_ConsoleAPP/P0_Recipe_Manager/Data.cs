using System.Text.Json;

// Class responsible for handling data serialization and deserialization
class Data 
{ 
    // Asynchronously serializes a list of recipes and saves it to a file
    public static async Task AsyncSerializeData(List<Recipe> recipes) 
    { 
        // Convert the list of recipes to a JSON string
        string recipeList = JsonSerializer.Serialize(recipes); 
        try 
        {
            // Create or overwrite the recipes.txt file
            using StreamWriter writer = File.CreateText("recipes.txt");
            // Asynchronously write the JSON string to the file
            await writer.WriteAsync(recipeList);
        } 
        catch (Exception e) 
        { 
            // If an error occurs during saving, print an error message
            Console.WriteLine($"Could not save changes: {e.Message}");
        }
    }

    // Deserializes recipes from a file and returns them as a List<Recipe>
    public static List<Recipe> DeserializeRecipes()
    { 
        try 
        {
            // Open and read the contents of the recipes.txt file
            using StreamReader reader = File.OpenText("recipes.txt");
            string jsonString = reader.ReadToEnd();
            // Deserialize the JSON string to a List<Recipe>
            // If deserialization fails or returns null, return an empty list
            return JsonSerializer.Deserialize<List<Recipe>>(jsonString) ?? [];
        } 
        catch(Exception e)
        {
            // If an error occurs during loading, print an error message
            Console.WriteLine($"Could not load data: {e.Message}");
            // Return an empty list if loading fails
            return [];
        }
    }
}