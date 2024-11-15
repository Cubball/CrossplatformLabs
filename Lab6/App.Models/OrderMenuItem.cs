namespace App.Models;

public class OrderMenuItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public Order Order { get; set; } = default!;

    public int MenuItemId { get; set; }

    public MenuItem MenuItem { get; set; } = default!;

    public int Quantity { get; set; }

    public string Comments { get; set; } = default!;
}
