using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllSpice.Models;
using AllSpice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FavoritesController : ControllerBase
  {
    private readonly FavoritesService _favoritesService;
    public FavoritesController(FavoritesService favoritesService)
    {
      _favoritesService = favoritesService;
    }
    [HttpGet]
    public ActionResult<List<Favorite>> GetAll()
    {
      try
      {
        List<Favorite> favorites = _favoritesService.GetAll();
        return Ok(favorites);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Favorite>> Create([FromBody] Favorite newFavorite)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newFavorite.AccountId = userInfo.Id;
        Favorite favorite = _favoritesService.Create(newFavorite);
        favorite.Creator = userInfo;
        return Ok(favorite);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}