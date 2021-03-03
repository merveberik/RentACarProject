using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarId).NotEmpty();
            //RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(c => c.CarId == 1);
            //RuleFor(c => c.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");  //ürün isimleri a ile başlamalı generate method
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A"); //A ile başlıyorsa true dönüyor.
        }
    }
}
