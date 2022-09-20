using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class IngredientsService {
    private readonly IngredientsRepository _ingredientsRepo;
    public IngredientsService(IngredientsRepository ingredientsRepo) {
      _ingredientsRepo = ingredientsRepo;
    }
    internal List<Ingredient> GetAll() {
      return _ingredientsRepo.GetAll();
    }
    internal Ingredient Create(Ingredient newIngredient) {
      return _ingredientsRepo.Create(newIngredient);
    }
  }
}