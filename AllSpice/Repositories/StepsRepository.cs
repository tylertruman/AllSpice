using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories {
  public class StepsRepository {
    private readonly IDbConnection _db;
    public StepsRepository(IDbConnection db) {
      _db = db;
    }
    internal List<Step> GetAll() {
      string sql = @"
      SELECT
      s.*,
      a.*
      FROM steps s
      JOIN accounts a ON a.id = s.creatorId;";
      List<Step> steps = _db.Query<Step, Account, Step>(sql, (step, account) => {
        step.Creator = account;
        return step;

      }).ToList();
      return steps;
    }
    internal Step Create(Step newStep) {
      string sql = @"
      INSERT INTO steps
      (position, body, recipeId, creatorId)
      VALUES
      (@position, @body, @recipeId, @creatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newStep);
      newStep.Id = id;
      return newStep;
    }
  }
}