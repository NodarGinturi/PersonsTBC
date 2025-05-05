using FluentValidation;
using Persons.Application.Contracts.Persistence;
using System.Text.RegularExpressions;

namespace Persons.Application.Features.Persons.Commands.Create;

public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    private readonly IUnitOfWork _unitOfWorkRepository;

    public CreatePersonCommandValidator(IUnitOfWork unitOfWorkRepository)
    {
        _unitOfWorkRepository = unitOfWorkRepository;


        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50)
            .WithMessage("FirstName  is not valid")
            .Must(BeOnlyEnglishOrOnlyGeorgian)
            .WithMessage("FirstName must contain only English or only Georgian letters (not both).");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50)
            .WithMessage("LastName  is not valid")
            .Must(BeOnlyEnglishOrOnlyGeorgian)
            .WithMessage("LastName must contain only English or only Georgian letters (not both).");

        RuleFor(x => x.PersonalNumber)
            .Length(11)
            .WithMessage("Pid is not valid");

        RuleFor(x => x.CityId)
            .GreaterThanOrEqualTo(1)
            .NotEmpty()
            .WithMessage("City  is not valid");

        RuleFor(x => x.Gender)
            .IsInEnum()
            .WithMessage("Gender is not valid");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(50)
            .WithMessage("Phone is not valid");

        RuleFor(x => x.BirthDate.Year)
            .NotEmpty()
            .GreaterThanOrEqualTo(18)
            .WithMessage("BirthDate Year is not valid");

        RuleFor(x => x.PhoneType)
            .NotEmpty()
            .IsInEnum()
            .WithMessage("Phone type is not valid");
    }

    private bool BeOnlyEnglishOrOnlyGeorgian(string? firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return false;

        var englishRegex = new Regex(@"^[a-zA-Z]+$");
        var georgianRegex = new Regex(@"^[ა-ჰ]+$");

        return englishRegex.IsMatch(firstName) || georgianRegex.IsMatch(firstName);
    }
}
