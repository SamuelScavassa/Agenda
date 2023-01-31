using System.ComponentModel.DataAnnotations;

namespace AppAgendaAPI.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    [MaxLength(50)]
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public string? UserAbout { get; set; }
}