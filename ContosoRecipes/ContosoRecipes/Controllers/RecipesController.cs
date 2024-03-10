using ContosoRecipes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ContosoRecipes.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        /// <summary>
        /// get the dishes from existing recipes
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetDishes([FromQuery]int count)
        {
            string[] recipes = { "Oxtail", "Curry Chicken", "Dumlings" };
            if(count <= 0)
                throw new Exception("Invalid call");

            if(recipes.Any())
                return Ok(recipes);
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateNewRecipes()
        {
            return Ok();
        }

        [HttpDelete("all")] // api/recipes/all
        public ActionResult DeleteRecipes()
        {
            if (false)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")] // api/recipes/12
        public ActionResult DeleteRecipes(string id)
        {
            if (false)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateRecipe(string id, JsonPatchDocument<Recipe> recipeUpdates)
        {
            return NoContent();
        }

    }
}

/*  Validation Attributes

Required
MaxLength
MinLength
Phone
Email
CreditCard
Range
Compare

*/
