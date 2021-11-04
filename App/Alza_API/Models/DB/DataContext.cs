using Microsoft.EntityFrameworkCore;


namespace Alza_API.Models.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
    }
}
