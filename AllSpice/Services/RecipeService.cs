namespace AllSpice.Services;

public class RecipeService
{
  private readonly RecipeRepository _repo;

  public RecipeService(RecipeRepository repo)
  {
    _repo = repo;
  }

  internal void deleteRecipe(int recipeId)
  {
    _repo.deleteRecipe(recipeId);
  }

  internal Recipe editRecipe(Recipe recipeEdit, Recipe oldRecipe)
  {
    oldRecipe.Category = recipeEdit.Category ?? oldRecipe.Category;
    oldRecipe.Title = recipeEdit.Title ?? oldRecipe.Title;
    oldRecipe.Img = recipeEdit.Img ?? oldRecipe.Img;
    oldRecipe.Instructions = recipeEdit.Instructions ?? oldRecipe.Instructions;
    _repo.editRecipe(oldRecipe);
    Recipe editedRecipe = this.getOne(oldRecipe.Id);
    return editedRecipe;
  }

  internal List<Recipe> getAll()
  {
    List<Recipe> recipes = _repo.getAll();
    return recipes;
  }

  internal Recipe getOne(int recipeId)
  {
    Recipe recipe = _repo.getOne(recipeId);
    return recipe;
  }

  internal Recipe initializeRecipe(Recipe recipeData)
  {
    int newRecipeId = _repo.initializeRecipe(recipeData);
    Recipe recipe = this.getOne(newRecipeId);
    return recipe;
  }
}
