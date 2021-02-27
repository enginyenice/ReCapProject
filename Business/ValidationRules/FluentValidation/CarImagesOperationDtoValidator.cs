/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

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