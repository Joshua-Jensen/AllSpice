namespace AllSpice.Models;

public class IngredientsService
{
  private readonly IngredientsRepository _repo;

  public IngredientsService(IngredientsRepository repo)
  {
    _repo = repo;
  }

  internal int destroyIng(int ingredientId)
  {
    int rowsAffected = _repo.destroyIng(ingredientId);
    return rowsAffected;
  }

  internal List<Ingredient> GetAllIngredients(int recipeId)
  {
    List<Ingredient> ingredients = _repo.GetALLIngredients(recipeId);
    return ingredients;
  }

  internal Ingredient initializeIngredient(Ingredient ingredientData)
  {
    Ingredient newIngredient = _repo.initializeIngredient(ingredientData);
    return newIngredient;
  }
}
