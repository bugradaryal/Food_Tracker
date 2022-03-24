using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class FoodValidator: AbstractValidator<Food>
    {
        public FoodValidator()
        {
            RuleFor(x => x.yemek_ismi).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez.");
            RuleFor(x => x.yemek_ismi).MaximumLength(40).WithMessage("Yemek ismi en fazla 40 karakter uzunluğunda olabilir.");
            RuleFor(x => x.yemek_ismi).
        }
    }
}
