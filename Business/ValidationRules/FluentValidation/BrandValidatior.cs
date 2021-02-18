/*
Created By Engin Yenice
enginyenice2626@gmail.com
*/

using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidatior : AbstractValidator<Brand>
    {
        public BrandValidatior()
        {
            RuleFor(brand => brand.BrandName).Empty();
        }
    }
}