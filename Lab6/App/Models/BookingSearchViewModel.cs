namespace App.Models;

public class BookingSearchViewModel
{
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? CustomerName { get; set; }

    public List<Booking> Results { get; set; } = [];

    public bool SearchPerformed { get; set; }
}
