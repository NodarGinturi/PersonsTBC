using FluentValidation;

namespace Persons.Application.Features.Persons.Commands.Update;

public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
{
    public UpdatePersonCommandValidator() 
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
