using FluentValidation;
using MarketSystem.BLL.DTOs.Account;
using MarketSystem.BLL.Validation.AccountGenericExtentionMethodValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.Validation.Account
{
    public class RegisterValidator:AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(f => f.FirstName).AccountAutoValidation("FirstName");
            RuleFor(l => l.LastNAme).AccountAutoValidation("LastName");
        }
    }
}
