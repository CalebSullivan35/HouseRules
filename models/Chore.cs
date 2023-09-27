using System.ComponentModel.DataAnnotations;

namespace HouseRules.Models;

public class Chore
{
  public int Id { get; set; }
  [MaxLength(100)][Required]
  public String Name { get; set; }
  [Range(1,5)][Required]
  public int Difficulty { get; set; }
  [Range(1,14)][Required]
  public int ChoreFrequencyDays { get; set; }
  public List<ChoreCompletion> ChoreCompletions { get; set; }
  public List <ChoreAssignment> ChoreAssignments { get; set; }

   public bool IsOverdue 
  {
    get {
      if (ChoreCompletions != null && ChoreCompletions.Count > 0)
      {
        DateTime recentlyCompletedDate = ChoreCompletions.Max(cc => cc.CompletedOn);
        DateTime dueDate = recentlyCompletedDate.AddDays(ChoreFrequencyDays);
        if (dueDate < DateTime.Now){
          return true;
        } else {
          return false;
        }
      }
      return true;
    }
  }
 }