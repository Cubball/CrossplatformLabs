using Microsoft.EntityFrameworkCore;

namespace App.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<StaffRole> StaffRoles { get; set; } = default!;

    public DbSet<Staff> Staff { get; set; } = default!;

    public DbSet<Table> Tables { get; set; } = default!;

    public DbSet<Order> Orders { get; set; } = default!;

    public DbSet<Booking> Bookings { get; set; } = default!;

    public DbSet<Menu> Menus { get; set; } = default!;

    public DbSet<OrderMenuItem> OrderMenuItems { get; set; } = default!;

    public DbSet<MenuItem> MenuItems { get; set; } = default!;

    public DbSet<MenuItemIngredient> MenuItemIngredients { get; set; } = default!;

    public DbSet<Ingredient> Ingredients { get; set; } = default!;

    public DbSet<IngredientType> IngredientTypes { get; set; } = default!;

    public DbSet<Customer> Customers { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.Entity<StaffRole>()
            .HasKey(static sr => sr.Code);

        _ = modelBuilder.Entity<Table>()
            .HasKey(static t => t.Number);

        _ = modelBuilder.Entity<Staff>()
            .HasKey(static s => s.Id);
        _ = modelBuilder.Entity<Staff>()
            .HasOne(static s => s.Role)
            .WithMany()
            .HasForeignKey(static s => s.RoleCode);

        _ = modelBuilder.Entity<Order>()
            .HasKey(static o => o.Id);
        _ = modelBuilder.Entity<Order>()
            .HasOne(static o => o.Table)
            .WithMany()
            .HasForeignKey(static o => o.TableNumber);
        _ = modelBuilder.Entity<Order>()
            .HasOne(static o => o.Staff)
            .WithMany(static s => s.Orders)
            .HasForeignKey(static o => o.StaffId);

        _ = modelBuilder.Entity<Menu>()
            .HasKey(static m => m.Id);

        _ = modelBuilder.Entity<MenuItem>()
            .HasKey(static mi => mi.Id);
        _ = modelBuilder.Entity<MenuItem>()
            .HasOne(static mi => mi.Menu)
            .WithMany()
            .HasForeignKey(static mi => mi.MenuId);

        _ = modelBuilder.Entity<OrderMenuItem>()
            .HasKey(static omi => omi.Id);
        _ = modelBuilder.Entity<OrderMenuItem>()
            .HasOne(static omi => omi.Order)
            .WithMany()
            .HasForeignKey(static omi => omi.OrderId);
        _ = modelBuilder.Entity<OrderMenuItem>()
            .HasOne(static omi => omi.MenuItem)
            .WithMany()
            .HasForeignKey(static omi => omi.MenuItemId);

        _ = modelBuilder.Entity<Customer>()
            .HasKey(static c => c.Id);

        _ = modelBuilder.Entity<Booking>()
            .HasKey(static b => b.Id);
        _ = modelBuilder.Entity<Booking>()
            .HasOne(static b => b.Table)
            .WithMany()
            .HasForeignKey(static b => b.TableNumber);
        _ = modelBuilder.Entity<Booking>()
            .HasOne(static b => b.Customer)
            .WithMany()
            .HasForeignKey(static b => b.CustomerId);

        _ = modelBuilder.Entity<IngredientType>()
            .HasKey(static it => it.Code);

        _ = modelBuilder.Entity<Ingredient>()
            .HasKey(static i => i.Id);
        _ = modelBuilder.Entity<Ingredient>()
            .HasOne(static i => i.Type)
            .WithMany()
            .HasForeignKey(static i => i.TypeCode);

        _ = modelBuilder.Entity<MenuItemIngredient>()
            .HasKey(static mii => mii.Id);
        _ = modelBuilder.Entity<MenuItemIngredient>()
            .HasOne(static mii => mii.MenuItem)
            .WithMany()
            .HasForeignKey(static mii => mii.MenuItemId);
        _ = modelBuilder.Entity<MenuItemIngredient>()
            .HasOne(static mii => mii.Ingredient)
            .WithMany()
            .HasForeignKey(static mii => mii.IngredientId);
    }
}
