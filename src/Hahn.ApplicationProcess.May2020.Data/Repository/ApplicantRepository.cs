using System;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.May2020.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicationProcess.May2020.Data.Repository
{
    /// <summary>
    ///     Repository implementation for applicant.
    /// </summary>
    public class ApplicantRepository : IApplicantRepository<Applicant>
    {
        private readonly ApplicantDatabaseContext _databaseContext;
        private readonly ILogger<ApplicantRepository> _logger;

        public ApplicantRepository(IServiceProvider services, ILogger<ApplicantRepository> logger)
        {
            var scope = services.CreateScope();
            _databaseContext = scope.ServiceProvider.GetRequiredService<ApplicantDatabaseContext>();
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task<Applicant> Create(Applicant applicant)
        {
            _logger.LogInformation("Executing {0} repository method for applicant {1}.", nameof(Create),
                applicant.EmailAddress);

            _databaseContext.Applicants.Add(applicant);

            var numberOfItemsCreated = await _databaseContext.SaveChangesAsync();

            if (numberOfItemsCreated == 1) return applicant;

            _logger.LogDebug("Number of items created:{0}.", numberOfItemsCreated);

            return null;
        }

        /// <inheritdoc />
        public async Task<Applicant> Update(Applicant applicant)
        {
            _logger.LogInformation("Executing {0} repository method for applicant {1}.", nameof(Update), applicant.Id);

            var existingApplicant = Get(applicant.Id);

            if (existingApplicant != null)
            {
                existingApplicant.CountryOfOrigin = applicant.CountryOfOrigin;
                existingApplicant.Hired = applicant.Hired;
                existingApplicant.Address = applicant.Address;
                existingApplicant.Age = applicant.Age;
                existingApplicant.EmailAddress = applicant.EmailAddress;
                existingApplicant.FamilyName = applicant.FamilyName;
                existingApplicant.Name = applicant.Name;

                _databaseContext.Applicants.Attach(existingApplicant);

                var numberOfItemsUpdated = await _databaseContext.SaveChangesAsync();

                if (numberOfItemsUpdated == 1)
                    return applicant;
            }

            return null;
        }

        /// <inheritdoc />
        public Applicant Get(int id)
        {
            _logger.LogInformation("Executing {0} repository method for applicant {1}.", nameof(Get), id);

            var applicant = _databaseContext.Applicants
                .FirstOrDefault(x => x.Id == id);

            return applicant;
        }

        /// <inheritdoc />
        public async Task<bool> Delete(int id)
        {
            _logger.LogInformation("Executing {0} repository method for applicant {1}.", nameof(Delete), id);

            var existingApplicant = Get(id);

            if (existingApplicant != null)
            {
                _databaseContext.Applicants.Remove(existingApplicant);
                var numberOfItemsDeleted = await _databaseContext.SaveChangesAsync();
                if (numberOfItemsDeleted == 1)
                    return true;
            }

            return false;
        }
    }
}