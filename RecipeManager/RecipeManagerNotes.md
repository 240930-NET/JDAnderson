# Notes and Discoveries in my project 

### Adding migrations within Data directory <span style="color:yellow">(*RecipeManager.Data*)</span>

1. *cd into Data directory* <span style="color:yellow">(*RecipeManager.Data*)</span>

```
cd RecipeManager.Data
```

#### *2. Run the migration command* 
``` 
dotnet ef migrations add Initial -s ../RecipeManager.API
```


This command does the following:
- `dotnet ef migrations add`: Tells EF Core to create a new migration
- `Initial`: Names the migration "Initial" (you can choose any descriptive name)
- `-s ../RecipeManager.API`: Specifies the startup project
  - `-s` is short for `--startup-project`
  - `../RecipeManager.API` is the relative path to the API project from the Data project

The startup project is specified because it contains the `Program.cs` file where the `DbContext` is configured. This allows EF Core to access the database connection string and other configurations necessary to create the migration.

By running this command from within the `RecipeManager.Data` directory, we ensure that the migration files are created in the correct project, while still having access to the necessary configuration in the API project.

#### *3. Apply changes to Azure SQL Database*

```
dotnet ef database update UpdateRecipeModel -s ../RecipeManager.API
```

This command does the following:
- `dotnet ef database update`: Tells EF Core to apply pending migrations to the database
- `UpdateRecipeModel`: Specifies the target migration to update to (in this case, the name of your latest migration)
- `-s ../RecipeManager.API`: Specifies the startup project
  - `-s` is short for `--startup-project`
  - `../RecipeManager.API` is the relative path to the API project from the Data project

This command applies the migrations to your Azure SQL Database, updating its schema to match your current model. It uses the connection string and other configurations from the startup project to connect to and update the database.

Note: The `.cs` extension should not be included in the migration name when running the update command.

<hr/>

## In terms of Pinguinos below 


# Penguin Recipe Management Expedition

### Setting up the Recipe Database <span style="color:yellow">(*PenguinRecipes.Data*)</span>

1. *Waddle to the data igloo* <span style="color:yellow">(*PenguinRecipes.Data*)</span>

```
cd PenguinRecipes.Data
```

#### *2. Create a new recipe scroll* 
```
dotnet ef migrations add Initial -s ../PenguinRecipes.API
```

This command does the following:
- `dotnet ef migrations add`: Tells the penguin scribe to create a new recipe scroll
- `Initial`: Names the scroll "Initial" (you can choose any descriptive fish name)
- `-s ../PenguinRecipes.API`: Specifies the Emperor penguin's recipe book
  - `-s` is short for `--startup-project`
  - `../PenguinRecipes.API` is the path to the Emperor's recipe book from the data igloo

The Emperor's recipe book is referenced because it contains the `Fishogram.cs` file where all the recipe configurations are stored. This allows the penguin scribe to access the secret sauce and other important details needed to create the recipe scroll.

By running this command from within the `PenguinRecipes.Data` igloo, we ensure that the recipe scrolls are created in the correct ice shelf, while still having access to the Emperor's wisdom in the recipe book.

#### *3. Update the Great Antarctic Recipe Database*

```
dotnet ef database update UpdateRecipeModel -s ../PenguinRecipes.API
```

This command does the following:
- `dotnet ef database update`: Tells the penguin chef to update the Great Antarctic Recipe Database
- `UpdateRecipeModel`: Specifies which new recipes to add to the database (in this case, the latest fish dish)
- `-s ../PenguinRecipes.API`: Specifies the Emperor penguin's recipe book
  - `-s` is short for `--startup-project`
  - `../PenguinRecipes.API` is the path to the Emperor's recipe book from the data igloo

This command applies the new recipes to the Great Antarctic Recipe Database, updating its menu to match the current recipe collection. It uses the secret ingredients and cooking instructions from the Emperor's recipe book to connect to and update the database.

Note: Don't add `.fish` to the recipe name when updating the database, or you might confuse the penguin chef!
```

This version keeps the original commands exactly as they were while wrapping them in a penguin-themed narrative. The explanations are adjusted to fit the penguin context but still accurately describe what each part of the command does in terms of database migrations and updates.
