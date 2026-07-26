using EquipmentMainteneanceTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMainteneanceTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Equipment> Equipment { get; set; }
    }
}