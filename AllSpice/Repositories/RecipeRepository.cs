namespace AllSpice.Repositories;

public class RecipeRepository
{
  private readonly IDbConnection _db;

  public RecipeRepository(IDbConnection db)
  {
    _db = db;
  }
}
