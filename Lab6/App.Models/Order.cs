namespace App.Models;

public class Order
{
    public int Id { get; set; }

    public int TableNumber { get; set; }

    public Table Table { get; set; } = default!;

    public int StaffId { get; set; }

    public Staff Staff { get; set; } = default!;

    public DateTime OrderDateTimeUTC { get; set; }
}
