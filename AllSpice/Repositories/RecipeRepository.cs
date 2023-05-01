namespace AllSpice.Repositories;

public class RecipeRepository
{
  private readonly IDbConnection _db;

  public RecipeRepository(IDbConnection db)
  {
    _db = db;
  }

  internal void deleteRecipe(int recipeId)
  {
    string sql = @"
    DELETE FROM recipes WHERE id = @recipeId LIMIT 1
    ;";
    _db.Execute(sql, new { recipeId });
  }

  internal void editRecipe(Recipe oldRecipe)
  {
    string sql = @"
  UPDATE recipes
  SET 
  title = @Title,
  instructions = @Instructions,
  img = @Img,
category = @Category
WHERE id = @Id
  ;";
    _db.Execute(sql, oldRecipe);
  }

  internal List<Recipe> getAll()
  {
    string sql = @"
  SELECT recipes.* ,
  creator.*
  FROM recipes
  JOIN accounts creator ON creator.id = recipes.creatorId
    ;";
    List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
      recipe.Creator = account;
      return recipe;
    }).ToList();
    return recipes;
  }

  internal Recipe getOne(int recipeId)
  {
    string sql = @"
  SELECT r.*,
  creator.*
  FROM recipes r
    JOIN accounts creator ON creator.id = r.creatorId
  WHERE r.id = @recipeId
      ;";
    Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
      recipe.Creator = account;
      return recipe;
    }, new { recipeId }).FirstOrDefault();
    return recipe;
  }

  internal int initializeRecipe(Recipe recipeData)
  {
    string sql = @"
  INSERT INTO recipes
  (instructions, img, category, creatorId, title)
  VALUES(@Instructions, @Img, @Category, @creatorId, @Title);
SELECT LAST_INSERT_ID();";

    int newRecipeId = _db.Query<int>(sql, recipeData).FirstOrDefault();
    return newRecipeId;
  }
}
