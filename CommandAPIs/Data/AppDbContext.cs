using CommandAPIs.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandAPIs.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Commands> Commands { get; set; }
    }
}