namespace App.Models;

public class MenuItemIngredient
{
    public int Id { get; set; }

    public int IngredientId { get; set; }

    public Ingredient Ingredient { get; set; } = default!;

    public int MenuItemId { get; set; }

    public MenuItem MenuItem { get; set; } = default!;

    public int ItemQuantity { get; set; }

    public decimal StandartCost { get; set; }
}
