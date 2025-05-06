using FluentValidation;

namespace Persons.Application.Features.Persons.Queries;

public class GetPersonQueryValidator : AbstractValidator<GetPersonQuery>
{
    public GetPersonQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
