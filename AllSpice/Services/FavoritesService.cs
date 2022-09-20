using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class FavoritesService {
    private readonly FavoritesRepository _favoritesRepo;
    public FavoritesService(FavoritesRepository favoritesRepo) {
      _favoritesRepo = favoritesRepo;
    }
    internal List<Favorite> GetAll() {
      return _favoritesRepo.GetAll();
    }
    internal Favorite Create(Favorite newFavorite) {
      return _favoritesRepo.Create(newFavorite);
    }
  }
}