using FluentValidation;
using MarketSystem.BLL.DTOs.Produtc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.Validation.Category
{
    public class CategoryUpdateValidator:AbstractValidator<CategoryUpdateDTO>
    {
        public CategoryUpdateValidator()
           => Include(new CategorAddValidator());
        
    }
}
