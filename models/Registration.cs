using System.ComponentModel.DataAnnotations;

namespace HouseRules.Models;

public class Registration
{
    [EmailAddress]
    [MaxLength(50)]
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }

}