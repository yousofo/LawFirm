using LawFirm.Domain.Entities;
using LawFirm.Domain.Repos;
using LawFirm.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Infrastructure.Repos
{
    public class LawyersRepo(ApplicationDbContext dbContext) : ILawyersRepo
    {
        public async Task<IEnumerable<Lawyer>> GetLawyers()
        {
            var lawyers =await dbContext.Lawyers.ToListAsync();
            return lawyers;
        }
        public async Task<Lawyer?> GetLawyer(int id)
        {
            var lawyer= await dbContext.Lawyers.FirstOrDefaultAsync(e=>e.Id == id);
            return lawyer;
        }
        
        public async Task<bool> DeleteLawyer(int id)
        {
            var lawyer = await dbContext.Lawyers.FirstOrDefaultAsync(e => e.Id == id);

            if (lawyer == null)
            {
                return false;
            }

            dbContext.Lawyers.Remove(lawyer);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<int> CreateLawyer(Lawyer lawyer)
        {
            dbContext.Lawyers.Add(lawyer);
            await dbContext.SaveChangesAsync();
            return lawyer.Id;
        }    
        public async Task<int> UpdateLawyer(Lawyer lawyer)
        {
            dbContext.Lawyers.Update(lawyer);
            await dbContext.SaveChangesAsync();
            return lawyer.Id;
        }
    }
}
