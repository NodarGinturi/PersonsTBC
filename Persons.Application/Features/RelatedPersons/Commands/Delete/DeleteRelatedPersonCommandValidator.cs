using FluentValidation;

namespace Persons.Application.Features.RelatedPersons.Commands.Delete;

public class DeleteRelatedPersonCommandValidator : AbstractValidator<DeleteRelatedPersonCommand>
{
    public DeleteRelatedPersonCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id should be greater than 0");
    }
}
