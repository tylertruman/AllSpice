using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class StepsService {
    private readonly StepsRepository _stepsRepo;
    public StepsService(StepsRepository stepsRepo) {
      _stepsRepo = stepsRepo;
    }
    internal List<Step> GetAll() {
      return _stepsRepo.GetAll();
    }
    internal Step Create(Step newStep) {
      return _stepsRepo.Create(newStep);
    }
  }
}