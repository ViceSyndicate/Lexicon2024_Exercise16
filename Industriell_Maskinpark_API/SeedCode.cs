using Industriell_Maskinpark_API.Models;

namespace Industriell_Maskinpark_API
{
    public class SeedCode
    {
        public SeedCode(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<MachineDbContext>();

                if (!context.Machines.Any())
                {
                    context.Machines.AddRange(
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
                        },
                        new Machine
                        {
                            Id = Guid.NewGuid(),
                            Name = "Volvo Truck",
                            Status = false,
                            LastMessage = "Going to sleep.",
                            LatestContact = DateTime.Now
                        },
                        new Machine
                        {
                            Id = Guid.NewGuid(),
                            Name = "Volvo Scooper",
                            Status = true,
                            LastMessage = "Scoopin'",
                            LatestContact = DateTime.Now
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
