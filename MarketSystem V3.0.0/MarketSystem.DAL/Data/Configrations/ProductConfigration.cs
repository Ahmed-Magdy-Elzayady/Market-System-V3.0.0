using MarketSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.DAL.Data.Configrations
{
    internal class ProductConfigration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.HasOne(o => o.Category)
                 .WithMany(i => i.Products)
                 .HasForeignKey(u => u.CategoryModelId)
                 .IsRequired();
        }
    }
}
