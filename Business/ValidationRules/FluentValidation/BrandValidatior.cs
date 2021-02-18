using System;
using System.Collections.Generic;
using System.Text;
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
