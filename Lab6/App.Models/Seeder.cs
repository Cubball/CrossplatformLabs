using Microsoft.EntityFrameworkCore;

namespace App.Models;

public static class Seeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        await context.Database.MigrateAsync();

        if (context.StaffRoles.Any())
        {
            return;
        }

        List<StaffRole> staffRoles =
        [
            new StaffRole { Code = "WAITER", Description = "Waiter" },
            new StaffRole { Code = "CHEF", Description = "Chef" },
            new StaffRole { Code = "MANAGER", Description = "Manager" }
        ];
        await context.StaffRoles.AddRangeAsync(staffRoles);
        _ = await context.SaveChangesAsync();

        List<Staff> staff =
        [
            new Staff { RoleCode = "WAITER", FirstName = "John", LastName = "Doe" },
            new Staff { RoleCode = "CHEF", FirstName = "Jane", LastName = "Smith" },
            new Staff { RoleCode = "MANAGER", FirstName = "Alice", LastName = "Wonderland" },
        ];
        await context.Staff.AddRangeAsync(staff);
        _ = await context.SaveChangesAsync();

        List<Table> tables =
        [
            new Table { Number = 1, Details = "Table for 2" },
            new Table { Number = 2, Details = "Table for 4" },
            new Table { Number = 3, Details = "Table for 6" },
        ];
        await context.Tables.AddRangeAsync(tables);
        _ = await context.SaveChangesAsync();

        List<Customer> customers =
        [
            new Customer { FirstName = "Bob", Surname = "Smith", EmailAddress = "bob.smith@example.com", PhoneNumber = "01234567890", CellphoneNumber = "07123456789", OtherDetails = "None" },
            new Customer { FirstName = "Alice", Surname = "Jones", EmailAddress = "alice.jones@example.com", PhoneNumber = "09876543210", CellphoneNumber = "07987654321", OtherDetails = "None" },
        ];
        await context.Customers.AddRangeAsync(customers);
        _ = await context.SaveChangesAsync();

        var booking = new Booking
        {
            CustomerId = customers[0].Id,
            TableNumber = tables[0].Number,
            DateBookingMadeUTC = DateTime.UtcNow,
            DateTableBookedForUTC = DateTime.UtcNow.AddDays(1),
            NumberInParty = 2,
        };
        _ = await context.Bookings.AddAsync(booking);
        _ = await context.SaveChangesAsync();

        List<IngredientType> ingredientTypes =
        [
            new IngredientType { Code = "MEAT", Description = "Meat" },
            new IngredientType { Code = "VEGETABLE", Description = "Vegetable" },
            new IngredientType { Code = "FRUIT", Description = "Fruit" },
            new IngredientType { Code = "DAIRY", Description = "Dairy" },
            new IngredientType { Code = "OTHER", Description = "Other" },
        ];
        await context.IngredientTypes.AddRangeAsync(ingredientTypes);
        _ = await context.SaveChangesAsync();

        List<Ingredient> ingredients =
        [
            new Ingredient { Name = "Beef", TypeCode = "MEAT" },
            new Ingredient { Name = "Carrot", TypeCode = "VEGETABLE" },
            new Ingredient { Name = "Apple", TypeCode = "FRUIT" },
            new Ingredient { Name = "Milk", TypeCode = "DAIRY" },
            new Ingredient { Name = "Salt", TypeCode = "OTHER" },
        ];
        await context.Ingredients.AddRangeAsync(ingredients);
        _ = await context.SaveChangesAsync();

        var menu = new Menu { DateUTC = DateTime.UtcNow };
        _ = await context.Menus.AddAsync(menu);
        _ = await context.SaveChangesAsync();

        List<MenuItem> menuItems =
        [
            new MenuItem { MenuId = menu.Id, Description = "Beef Stew", Price = 10.00m },
            new MenuItem { MenuId = menu.Id, Description = "Carrot Soup", Price = 5.00m },
            new MenuItem { MenuId = menu.Id, Description = "Apple Pie", Price = 3.00m },
            new MenuItem { MenuId = menu.Id, Description = "Milkshake", Price = 2.00m },
            new MenuItem { MenuId = menu.Id, Description = "Salted Caramel Ice Cream", Price = 4.00m },
        ];
        await context.MenuItems.AddRangeAsync(menuItems);
        _ = await context.SaveChangesAsync();

        List<MenuItemIngredient> menuItemIngredients =
        [
            new MenuItemIngredient { MenuItemId = menuItems[0].Id, IngredientId = ingredients[0].Id, ItemQuantity = 1, StandartCost = 1.00m },
            new MenuItemIngredient { MenuItemId = menuItems[1].Id, IngredientId = ingredients[1].Id, ItemQuantity = 1, StandartCost = 0.50m },
            new MenuItemIngredient { MenuItemId = menuItems[2].Id, IngredientId = ingredients[2].Id, ItemQuantity = 1, StandartCost = 0.30m },
            new MenuItemIngredient { MenuItemId = menuItems[3].Id, IngredientId = ingredients[3].Id, ItemQuantity = 1, StandartCost = 0.20m },
        ];
        await context.MenuItemIngredients.AddRangeAsync(menuItemIngredients);
        _ = await context.SaveChangesAsync();

        var order = new Order { TableNumber = tables[0].Number, StaffId = staff[0].Id, OrderDateTimeUTC = DateTime.UtcNow };
        _ = await context.Orders.AddAsync(order);
        _ = await context.SaveChangesAsync();

        List<OrderMenuItem> orderMenuItems =
        [
            new OrderMenuItem { OrderId = order.Id, MenuItemId = menuItems[0].Id, Quantity = 1, Comments = "No onions" },
            new OrderMenuItem { OrderId = order.Id, MenuItemId = menuItems[1].Id, Quantity = 1, Comments = "Extra salt" },
            new OrderMenuItem { OrderId = order.Id, MenuItemId = menuItems[2].Id, Quantity = 1, Comments = "No cream" },
        ];
        await context.OrderMenuItems.AddRangeAsync(orderMenuItems);
        _ = await context.SaveChangesAsync();
    }
}
