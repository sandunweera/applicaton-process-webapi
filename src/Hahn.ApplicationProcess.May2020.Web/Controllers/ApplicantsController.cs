using System.Threading.Tasks;
using Hahn.ApplicationProcess.May2020.Data.Models;
using Hahn.ApplicationProcess.May2020.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicationProcess.May2020.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantService<Applicant> _applicantService;
        private readonly ILogger<ApplicantsController> _logger;

        public ApplicantsController(IApplicantService<Applicant> applicantService, ILogger<ApplicantsController> logger)
        {
            _applicantService = applicantService;
            _logger = logger;
        }

        /// <summary>
        ///     Get an applicant by id.
        /// </summary>
        /// <param name="id">Id of the applicant.</param>
        /// <returns>Retrieved applicant.</returns>
        [HttpGet("/api/applicants/{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("Executing {0} action method.", nameof(Get));

            var applicant = _applicantService.Get(id);
            if (applicant == null) return NotFound();

            return Ok(applicant);
        }

        /// <summary>
        ///     Create an applicant.
        /// </summary>
        /// <param name="applicant">Applicant to be created.</param>
        /// <returns>Created applicant.</returns>
        [HttpPost("/api/applicants")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] Applicant applicant)
        {
            _logger.LogInformation("Executing {0} action method.", nameof(Post));

            var result = await _applicantService.Create(applicant);

            var url = Url.Link(nameof(Get), new {id = result.Id});
            return Created(url, result);
        }

        /// <summary>
        ///     Update a given applicant.
        /// </summary>
        /// <param name="id">Id of the applicant to be updated.</param>
        /// <param name="applicant">Updated applicant data.</param>
        /// <returns>Updated applicant.</returns>
        [HttpPut("/api/applicants/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] Applicant applicant)
        {
            _logger.LogInformation("Executing {0} action method.", nameof(Put));

            applicant.Id = id;
            var result = await _applicantService.Update(applicant);

            if (result != null) return Ok(result);

            return NotFound();
        }

        /// <summary>
        ///     Delete an applicant by id.
        /// </summary>
        /// <param name="id">Id of the applicant to be deleted.</param>
        /// <returns>Deletion status.</returns>
        [HttpDelete("/api/applicants/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Executing {0} action method.", nameof(Delete));

            var result = await _applicantService.Delete(id);

            if (result) return Ok();

            return NotFound();
        }
    }
}