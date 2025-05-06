using FluentValidation;

namespace Persons.Application.Features.Persons.Commands.Delete;

public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
{
    public DeletePersonCommandValidator() 
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
