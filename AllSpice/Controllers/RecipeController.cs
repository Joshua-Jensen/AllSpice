namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
  private readonly RecipeService _recipeService;

  public RecipeController(RecipeService recipeService)
  {
    _recipeService = recipeService;
  }


}
