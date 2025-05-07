using FluentValidation;

namespace Persons.Application.Features.RelatedPersons.Queries;

public class GetRelatedPersonQueryValidator : AbstractValidator<GetRelatedPersonQuery>
{
    public GetRelatedPersonQueryValidator() 
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
