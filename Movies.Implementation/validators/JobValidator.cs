using FluentValidation;
using Movies.Application.Dto;
using Movies.DataAccess;
using Movies.Implementation.validators.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Implementation.validators
{
    public class JobValidator : AbstractValidator<JobDto>
    {
        private readonly AppDbContext context;

        public JobValidator(AppDbContext context)
        {
            RuleFor(x => x.Name)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage(ValidationMessages.IsRequired("Job Name"))
                 .Matches(ValidFormatRegex.ValidNameFormat);

            this.context = context;
        }
    }
}
