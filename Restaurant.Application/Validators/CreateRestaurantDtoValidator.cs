using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Validator;
public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    private readonly List<string> validCategories = ["Italian","Mexican","Japaness","American","Indian"];
    public CreateRestaurantDtoValidator()
    {
        RuleFor(dto => dto.Name)
        .Length(3, 100);

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required");

        RuleFor(dto => dto.Category)
            .NotEmpty().WithMessage("Category is required");
        RuleFor(dto => dto.Category)
            .Must(category => validCategories.Contains(category))
            .WithMessage("Invalid category.Please choose from the valid categories.");

        RuleFor(dto => dto.ContactEmail)
          .EmailAddress()
          .WithMessage("Please provide a valid email address");

        RuleFor(dto => dto.PostalCode)
          .Matches(@"^\d{2}-\d{3}$")
          .WithMessage("Please provide a valid postal code (XX-XXX).");

    }
}
