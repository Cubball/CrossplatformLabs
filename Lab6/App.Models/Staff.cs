namespace App.Models;

public class Staff
{
    public int Id { get; set; }

    public string RoleCode { get; set; } = default!;

    public StaffRole Role { get; set; } = default!;

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public List<Order> Orders { get; set; } = [];
}
