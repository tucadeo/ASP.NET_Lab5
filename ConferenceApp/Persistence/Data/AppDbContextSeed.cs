using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceApp.Persistence.Entities;
using ConferenceApp.Persistence.Enums;

namespace ConferenceApp.Persistence.Data
{
    public static class AppDbContextSeed
    {
        public static async Task SeedData(AppDbContext context)
        {
            if (!context.ConferenceVariants.Any())
            {
                await context.ConferenceVariants.AddRangeAsync(GetPreconfiguredConferenceVariants());
                await context.SaveChangesAsync();
            }
        }

        private static IEnumerable<ConferenceVariant> GetPreconfiguredConferenceVariants()
        {
            return new List<ConferenceVariant>
            {
                new() { ConferenceType = ConferenceType.Lecture },
                new() { ConferenceType = ConferenceType.Workshop },
                new() { ConferenceType = ConferenceType.Remote },
            };
        }
    }
}