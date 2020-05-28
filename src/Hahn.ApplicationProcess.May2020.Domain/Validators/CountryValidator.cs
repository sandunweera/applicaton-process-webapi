using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Validators;
using Hahn.ApplicationProcess.May2020.Data.RestClient;

namespace Hahn.ApplicationProcess.May2020.Domain.Validators
{
    public class CountryValidator : AsyncValidatorBase
    {
        private readonly IRestClient _restClient;

        public CountryValidator(IRestClient restClient) : base("Country name '{PropertyValue}' is not valid.")
        {
            _restClient = restClient;
        }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context,
            CancellationToken cancellation)
        {
            return (await _restClient.GetAsync(
                $"https://restcountries.eu/rest/v2/name/{context.PropertyValue}?fullText=true")).IsSuccessStatusCode;
        }
    }
}