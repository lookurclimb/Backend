using System.Collections.ObjectModel;
using LevelUpCenter.Security.Domain.Models;

namespace LevelUpCenter.LookUrClimb.Domain.Models;

public class Coach
{
    public int Id { get; set; }

    public string Nickname { get; set; } = "";

    public string? TwitchUrl { get; set; }

    public bool Verified { get; set; }  = false;

    public User User { get; set; }
    public int UserId { get; set; }

    public Collection<Course> Courses { get; set; } = new();
}