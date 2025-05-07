using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Persons.Application.Contracts.Persistence;

namespace Persons.Application.Features.Persons.Commands.Image;

public record UploadImageCommand(int PersonId, IFormFile ImageFile) : IRequest<Result<UploadPersonImageResponse>>;

public record UploadPersonImageResponse(string ImageUrl);

public class UploadImageCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UploadImageCommand, Result<UploadPersonImageResponse>>
{
    public async Task<Result<UploadPersonImageResponse>> Handle(UploadImageCommand request, CancellationToken cancellationToken)
    {
        var _imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "persons");
        var person = await unitOfWork.PersonRepository.GetByIdAsync(request.PersonId, cancellationToken);

        if (person == null)
        {
            return Result.Failure<UploadPersonImageResponse>("Person does not exist");
        }

        var fileExtension = Path.GetExtension(request.ImageFile.FileName).ToLower();

        var fileName = $"{Guid.NewGuid()}{fileExtension}";
        var filePath = Path.Combine(_imageDirectory, fileName);

        Directory.CreateDirectory(_imageDirectory);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await request.ImageFile.CopyToAsync(stream, cancellationToken);
        }

        person.ImageUrl = $"/images/persons/{fileName}";
        await unitOfWork.PersonRepository.UpdateAsync(person, cancellationToken);

        return Result.Success(new UploadPersonImageResponse(person.ImageUrl));
    }
}