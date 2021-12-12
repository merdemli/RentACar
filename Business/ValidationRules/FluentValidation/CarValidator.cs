using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()  //costructor'da set edilirler
        {
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.CarName).MinimumLength(2);
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(1000).When(p => p.BrandId == 1);
           // RuleFor(p => p.CarName).Must(StartWirhA).WithMessage("Ürünler A harfi ilr başlamalı"); //kendi oluşturdugun kural 
        }

        //private bool StartWirhA(string arg) //arg : senin gönderdiğin parametre yani CarName
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
