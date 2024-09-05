using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public UserSettings? UserSettings { get; set; }
}

public class UserSettings
{
    [Key, ForeignKey("User")]
    public int UserId { get; set; }

    public string? Theme { get; set; }

    public bool NotificationsEnabled { get; set; }

    public User? User { get; set; }
}
