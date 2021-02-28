/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImagesOperationDtoValidator : AbstractValidator<CarImagesOperationDto>
    {
        public CarImagesOperationDtoValidator()
        {
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.CarId).NotNull();
        }
    }
}