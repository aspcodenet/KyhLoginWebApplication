using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KyhLoginWebApplication.Data;

public class DataInitializer
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public DataInitializer(ApplicationDbContext context, 
        UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public void SeedData()
    {
        _context.Database.Migrate();
        //Seeda data - skapa roller, skapa users EFTER RASTEN
        SeedRoles();
        SeedUsers();
    }

    private void SeedUsers()
    {
        CreateUserIfNotExists("stefan@banken.se","Hejsan123456#",
            new[]{"Admin"});

        CreateUserIfNotExists("stefankunden@banken.se", "Hejsan123456#", 
            new[] { "Customer" });

        CreateUserIfNotExists("stefanigen@banken.se", "Hejsan123456#", 
            new[] { "Admin", "Customer" });
    }

    private void CreateUserIfNotExists(string email, string password, string[] roles)
    {
        if (_userManager.FindByEmailAsync(email).Result != null) return;

        var user = new IdentityUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };
        _userManager.CreateAsync(user, password).Wait();
        _userManager.AddToRolesAsync(user, roles).Wait();

    }

    private void SeedRoles()
    {
        CreateRoleIfNotExists("Admin");
        CreateRoleIfNotExists("Customer");
    }

    private void CreateRoleIfNotExists(string rolename)
    {
        if (_context.Roles.Any(e => e.Name == rolename))
            return;
        _context.Roles.Add(new IdentityRole{ Name=rolename, NormalizedName = rolename});
        _context.SaveChanges();
    }
}