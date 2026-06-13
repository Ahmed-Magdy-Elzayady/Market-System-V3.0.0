using FluentValidation;
using MarketSystem.BLL.DTOs.Produtc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.Validation.Product
{
    public class ProductUpdateValidator:AbstractValidator<ProductUpdateDTO>
    {
        public ProductUpdateValidator()
           => Include(new ProductAddValidator());

        
    } 
}
