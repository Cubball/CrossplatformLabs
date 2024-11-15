namespace App.Models;

public class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string Surname { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public string CellphoneNumber { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;

    public string OtherDetails { get; set; } = default!;
}
