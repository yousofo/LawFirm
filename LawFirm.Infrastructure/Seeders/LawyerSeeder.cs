using LawFirm.Domain.Entities;
using LawFirm.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Infrastructure.Seeders
{
    public  class LawyerSeeder(ApplicationDbContext dbContext) : ILawyerSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Lawyers.Any())
                {
                    var lawyers = SeedLawyers();
                    await dbContext.Lawyers.AddRangeAsync(lawyers);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Lawyer> SeedLawyers()
        {
            var lawyers = new List<Lawyer>
            {
                new Lawyer
                {
                    Address=null,
                    Category="Criminal",
                    ContactEmail="test@test.com",
                    ContactNumber="1234567890",
                    Description="Criminal Lawyer",
                    IsAvailable=true,
                    Issues=null,
                    Name="John Doe"

                }, new Lawyer
                {
                    Address=null,
                    Category="love",
                    ContactEmail="test2@test.com",
                    ContactNumber="123456784190",
                    Description="love Lawyer",
                    IsAvailable=false,
                    Issues=null,
                    Name="bulldozer"

                },
             };
            return lawyers;
        }
    }
}
