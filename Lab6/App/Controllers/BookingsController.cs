using System.Globalization;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

public class BookingsController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;

    public IActionResult Search()
    {
        var viewModel = new BookingSearchViewModel
        {
            StartDate = DateTime.UtcNow.Date,
            EndDate = DateTime.UtcNow.Date.AddDays(7)
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Search(BookingSearchViewModel searchModel)
    {
        var query = _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.Table)
            .AsQueryable();
        if (searchModel.StartDate.HasValue)
        {
            query = query.Where(b => b.DateTableBookedForUTC >= searchModel.StartDate.Value.ToUniversalTime());
        }

        if (searchModel.EndDate.HasValue)
        {
            var endDate = searchModel.EndDate.Value.AddDays(1).ToUniversalTime();
            query = query.Where(b => b.DateTableBookedForUTC < endDate);
        }

        if (!string.IsNullOrWhiteSpace(searchModel.CustomerName))
        {
            var searchTerm = searchModel.CustomerName.Trim().ToLower(CultureInfo.InvariantCulture);
            query = query.Where(b =>
                b.Customer.FirstName.ToLower().Contains(searchTerm) ||
                b.Customer.Surname.ToLower().Contains(searchTerm));
        }

        searchModel.Results = await query
            .OrderBy(b => b.DateTableBookedForUTC)
            .ToListAsync();
        searchModel.SearchPerformed = true;
        return View(searchModel);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var booking = await _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.Table)
            .FirstOrDefaultAsync(b => b.Id == id);
        if (booking is null)
        {
            return NotFound();
        }

        return View(booking);
    }
}
