namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
  private readonly IngredientsService _ingredientsService;
  private readonly Auth0Provider _auth0Provider;

  public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0Provider)
  {
    _ingredientsService = ingredientsService;
    _auth0Provider = auth0Provider;
  }

  [HttpPost]
  [Authorize]
  public ActionResult<Ingredient> initializeIngredient([FromBody] Ingredient ingredientData)
  {
    try
    {
      Ingredient newIngredient = _ingredientsService.initializeIngredient(ingredientData);
      return Ok(newIngredient);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }

  }

  [HttpDelete("{ingredientId}")]
  [Authorize]
  public ActionResult<string> destroyIng(int ingredientId)
  {
    try
    {
      _ingredientsService.destroyIng(ingredientId);
      return Ok("ingredient ${ingredientId} was destroyed");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
