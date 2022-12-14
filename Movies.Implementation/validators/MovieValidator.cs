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
    public class MovieValidator : AbstractValidator<MovieDto>
    {
        public readonly AppDbContext context;

        public MovieValidator(AppDbContext context)
        {
            RuleFor(x => x.Title)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage(ValidationMessages.IsRequired("Title"));

            RuleFor(x => x.ReleaseDate)
                 .Cascade(CascadeMode.Stop)
                  .NotEmpty().WithMessage(ValidationMessages.IsRequired("Release date"));

            RuleFor(x => x.Time)
                             .Cascade(CascadeMode.Stop)
                             .NotEmpty().WithMessage(ValidationMessages.IsRequired("Movie runtime"))
                             .GreaterThan(1)
                             .LessThanOrEqualTo(300); ;
                            

            this.context = context;
        }
    }
}
