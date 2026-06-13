using FluentValidation;
using MarketSystem.BLL.DTOs.Produtc;
using MarketSystem.BLL.Validation.GenericExtentionMethodValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.Validation.Product
{
    public class ProductAddValidator:AbstractValidator<ProductAddDTO>
    {
        public ProductAddValidator()
        {
            RuleFor(o => o.Title)
                .ProductAutoValidation("Title")
                .MaximumLength(20).WithMessage("Title Must be less Than 20 characters ")
                .WithErrorCode("ERR:INVALID_TITLE");

            RuleFor(d=>d.Description)
                .ProductAutoValidation("Description")
                .MaximumLength(40).WithMessage("Title Must be less Than 40 characters ")
                .WithErrorCode("ERR:INVALID_DECS");

            RuleFor(p => p.Price)

                .InclusiveBetween(20, double.MaxValue).WithMessage("Price Can not be less than 20 $")
                .WithErrorCode("ERR:INVALID_PRICE");
            RuleFor(u => u.UnitOFStock)
                .GreaterThanOrEqualTo(0).WithMessage("Unit Of Stock Can not be less than 0")
                .WithErrorCode("ERR:INVALID_STOCK");


        }
    }
}
