class Recipe { 
    public string? Name {get; set;}

    public List<string> Ingredients { get; set; }
    public string? Instructions { get; set; }
    public string CookingTime {get; set;}

    public int Servings { get; set; }

    public Recipe() { 
        Ingredients = new List<string>();
    }

   
}