using FluentValidation;

namespace Persons.Application.Features.RelatedPersons.Commands.Update;

public class UpdateRelatedPersonCommandValidator : AbstractValidator<UpdateRelatedPersonCommand>
{
    public UpdateRelatedPersonCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.PersonalNumber).NotEmpty();
        RuleFor(x => x.CityId).GreaterThan(0);
        RuleFor(x => x.BirthDate).NotEmpty();
        RuleFor(x => x.Gender).IsInEnum();
    }
}
