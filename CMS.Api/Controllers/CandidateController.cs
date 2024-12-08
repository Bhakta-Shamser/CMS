using CMS.Application.Candidate.Commands;
using CMS.Application.Candidate.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<AddCandidateCommand> _validator;
        private readonly ILogger<CandidatesController> _logger;
        public CandidatesController(IMediator mediator, IValidator<AddCandidateCommand> validator, ILogger<CandidatesController> logger)
        {
            _mediator = mediator;
            _validator = validator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidate([FromBody] AddCandidateCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);
            _logger.LogInformation("Add Candidate api invoked.");
            if (!validationResult.IsValid)
            {
                return BadRequest(new { errors = validationResult.Errors.Select(e => e.ErrorMessage) });
            }
            var result = await _mediator.Send(command);
            if(result != "Updated successfully.")
                return CreatedAtAction(nameof(GetCandidate), new { email = command.Email }, result);
            else
                return Ok(new { message = result });
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetCandidate(string email)
        {
            _logger.LogInformation("Get Candidate api invoked.");
            var result = await _mediator.Send(new GetCandidateByEmailQuery(email));
            if (result == null)
                return NotFound(new
                {
                    Message = $"Candidate with email '{email}' was not found.",
                    StatusCode = 404
                });
            return result is null ? NotFound() : Ok(result);
        }
    }
}
