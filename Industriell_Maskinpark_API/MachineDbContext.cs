using Industriell_Maskinpark_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Industriell_Maskinpark_API
{
    public class MachineDbContext : DbContext
    {
        public MachineDbContext(DbContextOptions<MachineDbContext> options) : base(options)
        {

        }
        public DbSet<Machine> Machines { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Machine>().HasData(
            new Machine
            {
                Id = Guid.NewGuid(),
                Name = "CAT Bulldozer",
                Status = true,
                LastMessage = "Dozin'",
                LatestContact = DateTime.Now
            },
            new Machine
            {
                Id = Guid.NewGuid(),
                Name = "CAT Hauler",
                Status = true,
                LastMessage = "Transporting",
                LatestContact = DateTime.Now
            });
        }
    }
}
