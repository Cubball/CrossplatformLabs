namespace App.Models;

public class Booking
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = default!;

    public int TableNumber { get; set; }

    public Table Table { get; set; } = default!;

    public DateTime DateBookingMadeUTC { get; set; }

    public DateTime DateTableBookedForUTC { get; set; }

    public int NumberInParty { get; set; }
}
