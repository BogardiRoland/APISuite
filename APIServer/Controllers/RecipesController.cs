using APIServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIServer.Controllers
{
    public class RecipesController : ApiController
    {
        private Manager manager = new Manager (databaseName: "Manager");

        [HttpGet]
        public List<Recipe> GetAll ()
        {
            return manager.GetAll<Recipe>("Recipes");
        }

        [HttpPost]
        public void AddNew([FromBody]Recipe payload)
        {
            manager.CreateNew("Recipes", new Recipe {
                Name = payload.Name,
                Ingredients = payload.Ingredients,
                Description = payload.Description
            });
        }
    }
}
