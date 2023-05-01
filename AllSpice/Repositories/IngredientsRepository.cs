namespace AllSpice.Repositories;

public class IngredientsRepository
{
  private readonly IDbConnection _db;

  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal void destroyIng(int ingredientId)
  {
    throw new NotImplementedException();
  }

  internal List<Ingredient> GetALLIngredients(int recipeId)
  {
    string sql = @"
  SELECT * FROM ingredients WHERE recipeId = @recipeId
  ;";
    List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();
    return ingredients;
  }

  internal Ingredient initializeIngredient(Ingredient ingredientData)
  {
    string sql = @"
  INSERT INTO ingredients
  (name, quantity, recipeId)
  VALUES(@Name, @Quantity, @RecipeId);
  SELECT * FROM ingredients WHERE id = LAST_INSERT_ID();
  ";
    Ingredient newIngredient = _db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();
    return newIngredient;
  }
}
