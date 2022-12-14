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
    public class ActorValidator : AbstractValidator<ActorDto>
    {
        private readonly AppDbContext context;

        public ActorValidator(AppDbContext context)
        {
            RuleFor(a => a.FirstName)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage(ValidationMessages.IsRequired("Fist name"))
                 .Matches(ValidFormatRegex.ValidNameFormat);

            RuleFor(a => a.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(ValidationMessages.IsRequired("Last name"))
                .Matches(ValidFormatRegex.ValidNameFormat);


            RuleFor(x => x.Biography)
                       .Cascade(CascadeMode.Stop)
                       .Length(10, 200)
                       .When(x => x.Biography != null);

            this.context = context;
        }
    }
}
