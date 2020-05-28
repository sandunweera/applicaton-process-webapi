using System.Threading.Tasks;
using Hahn.ApplicationProcess.May2020.Data.Models;
using Hahn.ApplicationProcess.May2020.Data.Repository;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicationProcess.May2020.Domain.Services
{
    public class ApplicantService : IApplicantService<Applicant>
    {
        private readonly ILogger<ApplicantService> _logger;
        private readonly IApplicantRepository<Applicant> _repository;

        public ApplicantService(IApplicantRepository<Applicant> repository, ILogger<ApplicantService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task<Applicant> Create(Applicant applicant)
        {
            _logger.LogInformation("Executing {0} service method for applicant {1}.", nameof(Create),
                applicant.EmailAddress);
            return _repository.Create(applicant);
        }

        public Task<Applicant> Update(Applicant applicant)
        {
            _logger.LogInformation("Executing {0} service method for applicant {1}.", nameof(Update), applicant.Id);
            return _repository.Update(applicant);
        }

        public Applicant Get(int id)
        {
            _logger.LogInformation("Executing {0} service method for applicant {1}.", nameof(Get), id);
            return _repository.Get(id);
        }

        public Task<bool> Delete(int id)
        {
            _logger.LogInformation("Executing {0} service method for applicant {1}.", nameof(Delete), id);
            return _repository.Delete(id);
        }
    }
}