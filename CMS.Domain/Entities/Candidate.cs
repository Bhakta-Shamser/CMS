using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Candidate
    {
        // Primary key
        public string Email { get; private set; }

        // Properties
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string? PhoneNumber { get; private set; }
        public DateTime? AvailableFrom { get; private set; }
        public DateTime? AvailableTo { get; private set; }
        public string? LinkedInProfileUrl { get; private set; }
        public string? GithubProfileUrl { get; private set; }
        public string Comment { get; private set; }
        public Guid RowId { get; private set; } = Guid.NewGuid();

        private Candidate() { }
        public Candidate(
            string email,
            string firstName,
            string lastName,
            string? phoneNumber,
            Guid? rowId = null,
            DateTime? availableFrom = null,
            DateTime? availableTo = null,
            string? linkedInProfileUrl = "",
            string? githubProfileUrl = "",
            string comment = "")
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email is required", nameof(email));
            }

            Email = email;
            FirstName = firstName;
            LastName = lastName;
            //PhoneNumber = phoneNumber;
            AvailableFrom = availableFrom;
            AvailableTo = availableTo;
            LinkedInProfileUrl = linkedInProfileUrl;
            GithubProfileUrl = githubProfileUrl;
            Comment = comment;
            RowId = rowId ?? Guid.NewGuid();
        }

        
        public void AddComment(string comment)
        {
            Comment = comment;
        }

        // Equality override to use Email as the unique identifier
        public override bool Equals(object? obj)
        {
            return obj is Candidate candidate && Email == candidate.Email;
        }

        public override int GetHashCode()
        {
            return Email.GetHashCode();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} ({Email}), RowId: {RowId}";
        }
    }
}
