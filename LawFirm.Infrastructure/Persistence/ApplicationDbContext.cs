using LawFirm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Infrastructure.Persistence
{
    
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        internal DbSet<Lawyer> Lawyers { get; set; }
        internal DbSet<Issue> Issues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lawyer>().OwnsOne(l => l.Address);

            modelBuilder.Entity<Lawyer>().HasMany(l => l.Issues).WithOne().HasForeignKey(i => i.LawyerId).HasPrincipalKey(l => l.Id);
        }
    }
}
