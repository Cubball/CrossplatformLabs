namespace App.Models;

public class MenuItem
{
    public int Id { get; set; }

    public int MenuId { get; set; }

    public Menu Menu { get; set; } = default!;

    public string Description { get; set; } = default!;

    public decimal Price { get; set; }
}
