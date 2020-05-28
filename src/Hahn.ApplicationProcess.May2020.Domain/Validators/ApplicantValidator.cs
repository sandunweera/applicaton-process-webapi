using FluentValidation;
using Hahn.ApplicationProcess.May2020.Data.Models;
using Hahn.ApplicationProcess.May2020.Data.RestClient;

namespace Hahn.ApplicationProcess.May2020.Domain.Validators
{
    public class ApplicantValidator : AbstractValidator<Applicant>
    {
        public ApplicantValidator(IRestClient restClient)
        {
            RuleFor(m => m.Name).NotEmpty().MinimumLength(5);
            RuleFor(m => m.FamilyName).NotEmpty().MinimumLength(5);
            RuleFor(m => m.Address).NotEmpty().MinimumLength(10);
            RuleFor(m => m.Age).InclusiveBetween(20, 60);
            RuleFor(m => m.EmailAddress).EmailAddress();
            RuleFor(m => m.CountryOfOrigin).NotNull().SetValidator(new CountryValidator(restClient));
        }
    }
}