using AutoMapper;
using MarketSystem.BLL.AutoMapping;
using MarketSystem.BLL.Manager.Category;
using MarketSystem.BLL.Manager.Product;
using MarketSystem.DAL.Data.ApplicationContext;
using MarketSystem.DAL.Repositories.Categories;
using MarketSystem.DAL.Repositories.Products;
using Microsoft.EntityFrameworkCore;

namespace MArketSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<MarketSystemContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddAutoMapper(option =>
            {
                option.AddProfile(new MappingProfile());
            });

            builder.Services.AddScoped<IProductManager, ProductManager>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();

            builder.Services.AddScoped<ICategoryManager, CategoryManager>();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
