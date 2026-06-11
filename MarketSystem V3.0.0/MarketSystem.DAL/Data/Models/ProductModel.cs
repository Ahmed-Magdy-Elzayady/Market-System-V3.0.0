using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.DAL.Data.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int UnitOFStock { get; set; }
        public int CategoryModelId { get; set; }
        public virtual CategoryModel Category { get; set; }
    }
}
