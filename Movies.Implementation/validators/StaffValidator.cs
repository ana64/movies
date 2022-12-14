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
    public  class StaffValidator : AbstractValidator<StaffDto>
    {
        private readonly AppDbContext context;

        public StaffValidator(AppDbContext context)
        {
            RuleFor(a => a.FirstName)
                  .Cascade(CascadeMode.Stop)
                  .NotEmpty().WithMessage(ValidationMessages.IsRequired("Fist name"))
                  .Matches(ValidFormatRegex.ValidNameFormat);

            RuleFor(a => a.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(ValidationMessages.IsRequired("Last name"))
                .Matches(ValidFormatRegex.ValidNameFormat);

            this.context = context;
        }
    }
}
