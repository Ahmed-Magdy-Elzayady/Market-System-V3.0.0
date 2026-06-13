using FluentValidation;
using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.Validation.AccountGenericExtentionMethodValidation
{
    public static class AccountExtentionMethodValidation
    {   
        public static IRuleBuilderOptions<T,string> AccountAutoValidation<T>(this IRuleBuilderInitial<T,string> rule,string property)
        {
            return
            rule.NotEmpty().WithMessage($"{property} Can not be empty")
                .WithErrorCode($"ERR:EMPTY_{property}")
                .MaximumLength(15).WithMessage($"{property} Can not exced 15 characters")
                .WithErrorCode($"ERR:INVALID_LENGTH_OF{property}");
        }
    }
}
