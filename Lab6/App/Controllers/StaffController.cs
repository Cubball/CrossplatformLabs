using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class StaffController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        var staffList = await _context.Staff
            .Include(static s => s.Role)
            .OrderBy(static s => s.LastName)
            .ThenBy(static s => s.FirstName)
            .ToListAsync();
        return View(staffList);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var staff = await _context.Staff
            .Include(static s => s.Role)
            .FirstOrDefaultAsync(s => s.Id == id);
        if (staff is null)
        {
            return NotFound();
        }

        var recentOrders = await _context.Orders
            .Include(static o => o.Table)
            .Where(o => o.StaffId == id)
            .OrderByDescending(o => o.OrderDateTimeUTC)
            .Take(5)
            .ToListAsync();
        ViewData["RecentOrders"] = recentOrders;
        return View(staff);
    }
}
