namespace App.Models;

public class Ingredient
{
    public int Id { get; set; }

    public string TypeCode { get; set; } = default!;

    public IngredientType Type { get; set; } = default!;

    public string Name { get; set; } = default!;
}
