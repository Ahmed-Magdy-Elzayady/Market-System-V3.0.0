using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.Validation.GenericExtentionMethodValidation
{
    public static class ProductExtentionMethodValidation
    {
        public static IRuleBuilderOptions<T,string> ProductAutoValidation<T>(this IRuleBuilderInitial<T,string> rule,string property)
        {
            return
                rule.NotEmpty().WithMessage($"{property} Field Is Required").WithErrorCode($"ERR:EMPITY_{property}");
        }
    }
}
