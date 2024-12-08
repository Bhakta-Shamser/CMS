using CMS.Application.Candidate.Commands;
using FluentValidation;

namespace CMS.Application.Candidate.Validator
{
    public class AddCandidateCommandValidator : AbstractValidator<AddCandidateCommand>
    {
        public AddCandidateCommandValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100).WithMessage("First name must not exceed 100 characters.");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100).WithMessage("Last name must not exceed 100 characters.");

            RuleFor(c => c.PhoneNumber)
                .Matches(@"^\+?\d{10,15}$")
                .WithMessage("Phone number must be between 10 and 15 digits and can include a leading '+'.")
                .When(c => !string.IsNullOrWhiteSpace(c.PhoneNumber));

            RuleFor(c => c.AvailableFrom)
                .LessThanOrEqualTo(c => c.AvailableTo)
                .WithMessage("'Available From' must be earlier than or equal to 'Available To'.")
                .When(c => c.AvailableFrom.HasValue && c.AvailableTo.HasValue);

            RuleFor(c => c.LinkedInProfileUrl)
                .MaximumLength(200).WithMessage("LinkedIn profile URL must not exceed 200 characters.")
                .Matches(@"^(http|https)://").WithMessage("LinkedIn profile URL must start with http or https.")
                .When(c => !string.IsNullOrWhiteSpace(c.LinkedInProfileUrl));

            RuleFor(c => c.GithubProfileUrl)
                .MaximumLength(200).WithMessage("GitHub profile URL must not exceed 200 characters.")
                .Matches(@"^(http|https)://").WithMessage("GitHub profile URL must start with http or https.")
                .When(c => !string.IsNullOrWhiteSpace(c.GithubProfileUrl));

            RuleFor(c => c.Comment)
                .MaximumLength(1000).WithMessage("Comment must not exceed 1000 characters.");
        }
    }
}
