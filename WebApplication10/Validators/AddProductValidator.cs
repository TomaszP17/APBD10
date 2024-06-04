using FluentValidation;
using WebApplication10.ResponseModels;

namespace WebApplication10.Validators;

public class AddProductValidator : AbstractValidator<PostProductModel>
{
    public AddProductValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty()
            .WithMessage("Name can't be empty")
            .MaximumLength(100)
            .WithMessage("Name must be shorter than 100 chars");
        
        RuleFor(x => x.ProductWeight)
            .GreaterThanOrEqualTo(0).WithMessage("Min value is 0")
            .PrecisionScale(5, 2, true)
            .WithMessage("Max 5 digits, and 2 digits after dot");
        
        RuleFor(x => x.ProductWidth)
            .GreaterThanOrEqualTo(0).WithMessage("Min value is 0")
            .PrecisionScale(5, 2, true)
            .WithMessage("Max 5 digits, and 2 digits after dot");
        
        RuleFor(x => x.ProductHeight)
            .GreaterThanOrEqualTo(0).WithMessage("Min value is 0")
            .PrecisionScale(5, 2, true)
            .WithMessage("Max 5 digits, and 2 digits after dot");
        
        RuleFor(x => x.ProductDepth)
            .GreaterThanOrEqualTo(0).WithMessage("Min value is 0")
            .PrecisionScale(5, 2, true)
            .WithMessage("Max 5 digits, and 2 digits after dot");
    }
}