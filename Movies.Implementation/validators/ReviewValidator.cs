using FluentValidation;
using Movies.Application.Dto;
using Movies.DataAccess;
using System.Linq;
using Movies.Implementation.validators.helper;

namespace Movies.Implementation.validators
{
    public class ReviewValidator : AbstractValidator<RaviewDto>
    {
        public readonly AppDbContext context;

        public ReviewValidator(AppDbContext context)
        {
            RuleFor(x => x.MovieId)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .Must(x => context.Movies.Any(m => m.Id == x)).WithMessage(ValidationMessages.EntityNotInDatabase("Movie"));

            RuleFor(x => x.UserId)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .Must(x => context.Users.Any(u => u.Id == x)).WithMessage(ValidationMessages.EntityNotInDatabase("Movie"));

            RuleFor(x => x.Rate)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithName("Rate")
               .GreaterThan(0)
               .LessThanOrEqualTo(10);

            RuleFor(X => X.Comment)
                .Cascade(CascadeMode.Stop)
               .NotEmpty().WithName("Comment")
               .MinimumLength(3)
               .MaximumLength(350); 
         
              
            this.context = context;
   
        }
    }
}
