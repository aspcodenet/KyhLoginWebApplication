using Microsoft.EntityFrameworkCore;

namespace KyhLoginWebApplication.Data;

public class DataInitializer
{
    private readonly ApplicationDbContext _context;

    public DataInitializer(ApplicationDbContext context)
    {
        _context = context;
    }

    public void SeedData()
    {
        _context.Database.Migrate();
        //Seeda data - skapa roller, skapa users EFTER RASTEN
    }
}