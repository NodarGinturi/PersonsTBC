using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Persons.Application.Features.Persons.Commands.Image;

public class UploadPersonImageCommandValidator : AbstractValidator<UploadImageCommand>
{
    public UploadPersonImageCommandValidator()
    {
        RuleFor(x => x.ImageFile)
            .NotNull().WithMessage("Image file is required.")
            .Must(file => file != null && file.Length > 0)
                .WithMessage("Uploaded image file is empty.")
            .Must(HaveValidExtension)
                .WithMessage("Only .jpg, .jpeg, and .png files are allowed.");
    }

    private bool HaveValidExtension(IFormFile file)
    {
        if (file == null) return false;

        var extension = Path.GetExtension(file.FileName).ToLower();
        return extension is ".jpg" or ".jpeg" or ".png";
    }
}
