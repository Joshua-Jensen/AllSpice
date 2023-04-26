namespace AllSpice.Services;

public class RecipeService
{
  private readonly RecipeRepository _repo;

  public RecipeService(RecipeRepository repo)
  {
    _repo = repo;
  }
}
