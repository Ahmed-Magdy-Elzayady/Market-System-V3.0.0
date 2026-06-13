using FluentValidation;
using MarketSystem.BLL.DTOs.Produtc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.Validation.Category
{
    public class CategorAddValidator:AbstractValidator<CategoryAddDto>
    {
        public CategorAddValidator()
        {
            RuleFor(o => o.Name)
                .NotEmpty().WithMessage("Name Field Is Required")
                .WithErrorCode("ERR:INVALID NAME")
                .MaximumLength(15).WithMessage("Category Name Can Not Be Excedded 15 Characters")
                .WithErrorCode("ERR:LONG NAME");
        }
    }
}
