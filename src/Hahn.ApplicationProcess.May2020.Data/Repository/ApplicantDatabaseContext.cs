using Hahn.ApplicationProcess.May2020.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicationProcess.May2020.Data.Repository
{
    /// <summary>
    ///     Applicant database context.
    /// </summary>
    public class ApplicantDatabaseContext : DbContext
    {
        public ApplicantDatabaseContext(
            DbContextOptions<ApplicantDatabaseContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>()
                .HasKey(x => x.Id);
        }
    }
}