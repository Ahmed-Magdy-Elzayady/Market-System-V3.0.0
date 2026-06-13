using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.DTOs.Produtc
{

    public class ProductAddDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int UnitOFStock { get; set; }
        public int CategoryModelId { get; set; }
    }
}
