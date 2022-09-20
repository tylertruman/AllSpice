using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
  public class FavoritesRepository
  {
    private readonly IDbConnection _db;
    public FavoritesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Favorite> GetAll()
    {
      string sql = @"
      SELECT
      f.*,
      a.*
      FROM favorites f
      WHERE f.accountId = a.id
      JOIN account a ON a.id = f.accountId;";
      List<Favorite> favorites = _db.Query<Favorite, Account, Favorite>(sql, (favorite, account) =>
      {
        favorite.Creator = account;
        return favorite;
      }).ToList();
      return favorites;
    }
    internal Favorite Create(Favorite newFavorite)
    {
      string sql = @"
      INSERT INTO favorites
      (accountId, recipeId)
      VALUES
      (@accountId, @recipeId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newFavorite);
      // newFavorite.Id = id;
      return newFavorite;
    }
  }
}