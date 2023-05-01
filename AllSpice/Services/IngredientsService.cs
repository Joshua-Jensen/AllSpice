namespace AllSpice.Models;

public class IngredientsService
{
  private readonly IngredientsRepository _repo;

  public IngredientsService(IngredientsRepository repo)
  {
    _repo = repo;
  }

  internal void destroyIng(int ingredientId)
  {
    _repo.destroyIng(ingredientId);
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
