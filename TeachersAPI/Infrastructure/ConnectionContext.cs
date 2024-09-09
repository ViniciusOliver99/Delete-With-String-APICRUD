using Microsoft.EntityFrameworkCore;
using TeachersAPI.Domain.Model;

namespace TeachersAPI.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Teachers> teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql
            (
                "Server=localhost;" +
                "Port=7777;Database=teachers;" +
                "User Id=postgres;" +
                "Password=2653"
            );
    }
}
