using RecipeManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecipeManagerAPI.Controllers
{
    public class RecipesController : ApiController
    {
        private RecipeManager manager = new RecipeManager (databaseName: "RecipeManager");

        [HttpGet]
        public List<Recipe> GetAllRecipes ()
        {
            return manager.GetAll<Recipe>("Recipes");
        }

        [HttpPost]
        public void AddNewRecipe([FromBody]Recipe payload)
        {
            manager.CreateNew("Recipes", new Recipe {
                Name = payload.Name,
                Ingredients = payload.Ingredients,
                Description = payload.Description
            });
        }
    }
}
