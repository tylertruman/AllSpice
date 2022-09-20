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
  public class StepsController : ControllerBase
  {
    private readonly StepsService _stepsService;
    public StepsController(StepsService stepsService)
    {
      _stepsService = stepsService;
    }
    [HttpGet]
    public ActionResult<List<Step>> GetAll()
    {
      try
      {
        List<Step> steps = _stepsService.GetAll();
        return Ok(steps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Step>> Create([FromBody] Step newStep)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newStep.CreatorId = userInfo.Id;
        Step step = _stepsService.Create(newStep);
        step.Creator = userInfo;
        return Ok(step);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}