﻿using CMS.Application.Candidate.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<AddCandidateCommandValidator>();

            return services;
        }
    }
}
