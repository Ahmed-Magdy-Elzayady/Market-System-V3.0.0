using MarketSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.DTOs.Produtc
{
    public class ProductReadAllDTO
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int UnitOFStock { get; set; }
        public string CategoryName { get; set; }
       
    }
}
