namespace AllSpice.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipeController : ControllerBase
{
  private readonly RecipeService _recipeService;
  private readonly Auth0Provider _auth0Provider;
  private readonly IngredientsService _ingredientsService;

  public RecipeController(RecipeService recipeService, Auth0Provider auth0Provider, IngredientsService ingredientsService)
  {
    _recipeService = recipeService;
    _auth0Provider = auth0Provider;
    _ingredientsService = ingredientsService;
  }

  [HttpGet]
  public ActionResult<List<Recipe>> GetAll()
  {
    try
    {
      List<Recipe> recipes = _recipeService.getAll();
      return Ok(recipes);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("{recipeId}")]
  public ActionResult<Recipe> getOne(int recipeId)
  {
    try
    {
      Recipe recipe = _recipeService.getOne(recipeId);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      {
        return BadRequest(e.Message);
      }
    }

  }


  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Recipe>> initializeRecipe([FromBody] Recipe recipeData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      Recipe recipe = _recipeService.initializeRecipe(recipeData);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      {
        return BadRequest(e.Message);
      }
    }
  }

  [HttpPut("{recipeId}")]
  [Authorize]
  public async Task<ActionResult<Recipe>> editRecipe([FromBody] Recipe recipeEdit, int recipeId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Recipe oldRecipe = _recipeService.getOne(recipeId);
      if (oldRecipe.CreatorId != userInfo.Id)
      { return Unauthorized("you are not authorized to edit this post"); }
      Recipe editedRecipe = _recipeService.editRecipe(recipeEdit, oldRecipe);
      return Ok(editedRecipe);
    }
    catch (Exception e)
    {
      {
        return BadRequest(e.Message);
      }
    }
  }


  [HttpDelete("{recipeId}")]
  [Authorize]
  public async Task<ActionResult<string>> destoryRecipe(int recipeId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Recipe recipe = _recipeService.getOne(recipeId);
      if (recipe.CreatorId != userInfo.Id)
      {
        return Unauthorized($"you are not authorized to delete this recipe recipeId of {recipeId}, Titled {recipe.Title}");
      }
      _recipeService.deleteRecipe(recipeId);
      return Ok($"recipe at {recipeId} titled {recipe.Title} was deleted");
    }
    catch (Exception e)
    {
      {
        return BadRequest(e.Message);
      }
    }
  }
  [HttpGet("{recipeId}/ingredients")]
  public ActionResult<List<Ingredient>> GetAllIngredients(int recipeId)
  {
    try
    {
      List<Ingredient> ingredients = _ingredientsService.GetAllIngredients(recipeId);
      return Ok(ingredients);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }

  }

}
