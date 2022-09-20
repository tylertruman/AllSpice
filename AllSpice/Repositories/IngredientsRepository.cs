using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories {
  public class IngredientsRepository {
    private readonly IDbConnection _db;
    public IngredientsRepository(IDbConnection db) {
      _db = db;
    }
    internal List<Ingredient> GetAll() {
      string sql = @"
      SELECT
      i.*,
      a.*
      FROM ingredients i
      JOIN accounts a ON a.id = i.creatorId;";
      List<Ingredient> ingredients = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) => {
        ingredient.Creator = account;
        return ingredient;

      }).ToList();
      return ingredients;
    }
    internal Ingredient Create(Ingredient newIngredient) {
      string sql = @"
      INSERT INTO ingredients
      (name, quantity, recipeId, creatorId)
      VALUES
      (@name, @quantity, @recipeId, @creatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newIngredient);
      newIngredient.Id = id;
      return newIngredient;
    }
  }
}