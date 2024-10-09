using System.Text.Json;

class Data { 


    public static async Task AsyncSerializeData(List<Recipe> recipes) { 
        string recipeList = JsonSerializer.Serialize(recipes); 
        try {
            using StreamWriter writer = File.CreateText("recipes.txt");
            await writer.WriteAsync(recipeList);
        } catch (Exception e) { 
            Console.WriteLine($"Could not save changes: {e.Message}");
        }
    }

    public static List<Recipe> DeserializeRecipes(){ 
        try {
            using StreamReader reader = File.OpenText("recipes.txt");
            string jsonString = reader.ReadToEnd();
            return JsonSerializer.Deserialize<List<Recipe>>(jsonString);

        } catch(Exception e){
            Console.WriteLine($"Could not load data: {e.Message}");
            return [];
        }
    }
}