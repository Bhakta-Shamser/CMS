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
        public CandidatesController(IMediator mediator, IValidator<AddCandidateCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidate([FromBody] AddCandidateCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);

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
            var result = await _mediator.Send(new GetCandidateByEmailQuery(email));
            return result is null ? NotFound() : Ok(result);
        }
    }
}
