using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class RecipesService {
    private readonly RecipesRepository _recipesRepo;
    public RecipesService(RecipesRepository recipesRepo) {
      _recipesRepo = recipesRepo;
    }
    internal List<Recipe> GetAll() {
      return _recipesRepo.GetAll();
    }
    internal Recipe Create(Recipe newRecipe) {
      return _recipesRepo.Create(newRecipe);
    }
  }
}