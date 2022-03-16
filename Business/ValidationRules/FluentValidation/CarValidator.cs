using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(1);
            RuleFor(c => c.ModelYear).InclusiveBetween(1900, DateTime.Now.Year + 1);
            RuleFor(c => c.BrandId).GreaterThanOrEqualTo(1);
            RuleFor(c => c.ColorId).GreaterThanOrEqualTo(1);
        }
    }
}
