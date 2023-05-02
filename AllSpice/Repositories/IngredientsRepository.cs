namespace AllSpice.Repositories;

public class IngredientsRepository
{
  private readonly IDbConnection _db;

  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal int destroyIng(int ingredientId)
  {
    string sql = @"
  DELETE FROM ingredients WHERE id = @ingredientId
  ;";
    int rowsAffected = _db.Execute(sql, new { ingredientId });
    return rowsAffected;
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
