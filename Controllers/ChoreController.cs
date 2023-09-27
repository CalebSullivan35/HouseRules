using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using HouseRules.Models;
using HouseRules.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
namespace HouseRules.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ChoreController : ControllerBase {
  private HouseRulesDbContext _dbContext;

    public ChoreController(HouseRulesDbContext context)
    {
        _dbContext = context;
    }

    
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.Chores.Include(c => c.ChoreAssignments).Include(c=>c.ChoreCompletions).ToList());
    }

  [HttpGet("{id}")]
  [Authorize]
  public IActionResult GetChoreDetail(int id)
  {
    return Ok(_dbContext.Chores
    .Include(c => c.ChoreAssignments)
    .ThenInclude(ca => ca.UserProfile)
    .Include(c => c.ChoreCompletions)
    .SingleOrDefault(c => c.Id == id));  
  }

  [HttpPost("{userId}/complete")]
  [Authorize]
  public IActionResult CreateChoreCompletion(int userId, int ChoreId )
  {
    UserProfile foundUser = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == userId);
    Chore foundChore = _dbContext.Chores.SingleOrDefault(c => c.Id == ChoreId);


    if (foundUser != null && foundChore != null)
    {
      ChoreCompletion newChoreCompletion = new ChoreCompletion
      {
        UserProfileId = foundUser.Id,
        ChoreId = foundChore.Id,
        CompletedOn = DateTime.Now
      };
      _dbContext.Add(newChoreCompletion);
      _dbContext.SaveChanges();
      return NoContent();
    }
    return NotFound();
  }

[HttpPost]
[Authorize (Roles = "Admin")]
public IActionResult CreateChore(Chore chore)
{
    _dbContext.Chores.Add(chore);
    _dbContext.SaveChanges();
    return Created($"/api/chore/{chore.Id}", chore);
}

[HttpPut("{id}")]
[Authorize (Roles ="Admin")]
public IActionResult EditChore(int id, Chore chore)
{
    Chore ChoreToUpdate = _dbContext.Chores.SingleOrDefault(c => c.Id == id);
    if(ChoreToUpdate == null)
    {
      return NotFound();
    }
    else if (id != ChoreToUpdate.Id)
    {
      return BadRequest();
    }
    //these are the properties we wish to make editable
    ChoreToUpdate.Name = chore.Name;
    ChoreToUpdate.Difficulty = chore.Difficulty;
    ChoreToUpdate.ChoreFrequencyDays = chore.ChoreFrequencyDays;
    _dbContext.SaveChanges();
    return NoContent();

}

[HttpDelete("{id}")]
[Authorize (Roles ="Admin")]
public IActionResult DeleteChore(int id)
{
    Chore choreToDelete = _dbContext.Chores.SingleOrDefault(c => c.Id == id);
    if (choreToDelete == null)
    {
      return NotFound();
    }
    _dbContext.Chores.Remove(choreToDelete);
    _dbContext.SaveChanges();
    return NoContent();
}

[HttpPost("{userId}/assign")]
[Authorize (Roles = "Admin")]
public IActionResult AssignChore(int choreId, int userId)
{
    UserProfile foundUser = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == userId);
    Chore foundChore = _dbContext.Chores.SingleOrDefault(c => c.Id == choreId);
    if (foundChore == null || foundUser == null)
    {
      return NotFound();
    };

    ChoreAssignment choreAssignmentToAdd = new ChoreAssignment()
    {
      UserProfileId = foundUser.Id,
      ChoreId = foundChore.Id,
    };

    _dbContext.ChoreAssignments.Add(choreAssignmentToAdd);
    _dbContext.SaveChanges();
    return NoContent();
}


[HttpPost("{userId}/unassign")]
[Authorize (Roles = "Admin")]
public IActionResult UnassignChore(int choreId, int userId)
{
    UserProfile foundUser = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == userId);
    Chore foundChore = _dbContext.Chores.SingleOrDefault(c => c.Id == choreId);
    ChoreAssignment foundAssignment = _dbContext.ChoreAssignments.SingleOrDefault(ca => ca.ChoreId == foundChore.Id && ca.UserProfileId == foundUser.Id);
    if (foundChore == null || foundUser == null || foundAssignment == null)
    {
      return NotFound();
    };
    _dbContext.ChoreAssignments.Remove(foundAssignment);
    _dbContext.SaveChanges();
    return NoContent();
}

[HttpGet("mychores/{userId}")]
[Authorize]
public IActionResult GetMyChores(int userId)
{
    return Ok(_dbContext.ChoreAssignments
    .Include(ca => ca.Chore)
    .ThenInclude(c => c.ChoreCompletions)
    .Where(ca => ca.UserProfileId == userId)
    );
}

}