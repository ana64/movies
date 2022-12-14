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
    public class GenreValidator  : AbstractValidator<GenreDto>
    {
        private readonly AppDbContext context;

        public GenreValidator(AppDbContext context)
        {
            RuleFor(x => x.Name)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage(ValidationMessages.IsRequired("Ganre Name"))
                 .Matches(ValidFormatRegex.ValidNameFormat);


            this.context = context;
        }
    }
}
