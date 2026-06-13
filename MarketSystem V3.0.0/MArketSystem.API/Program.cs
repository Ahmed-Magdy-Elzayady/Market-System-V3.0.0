using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MarketSystem.BLL.AutoMapping;
using MarketSystem.BLL.Manager.Category;
using MarketSystem.BLL.Manager.Product;
using MarketSystem.BLL.Validation.Account;
using MarketSystem.BLL.Validation.Category;
using MarketSystem.BLL.Validation.Product;
using MarketSystem.DAL.Data.ApplicationContext;
using MarketSystem.DAL.Data.Models;
using MarketSystem.DAL.Repositories.Categories;
using MarketSystem.DAL.Repositories.Products;
using MArketSystem.API.AdminAccountCreation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace MArketSystem.API
{
    public class Program
    {
        public static async Task Main(string[] args)
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
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MarketSystemContext>();

            builder.Services.Configure<IdentityOptions>(option =>
            {
                option.SignIn.RequireConfirmedPhoneNumber = false;
                option.SignIn.RequireConfirmedEmail = false;
                option.User.RequireUniqueEmail = true;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 5;
                option.Password.RequireNonAlphanumeric = false;

            });
            builder.Services.AddScoped<IProductManager, ProductManager>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();

            builder.Services.AddScoped<ICategoryManager, CategoryManager>();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
           
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<ProductAddValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<ProductUpdateValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CategorAddValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<CategoryUpdateValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<RegisterValidator>();
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                var KeyFromSecret = builder.Configuration["SecretKey"];
                var keyInBytes = Encoding.ASCII.GetBytes(KeyFromSecret!);
                var MySK = new SymmetricSecurityKey(keyInBytes);
                option.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration.GetValue<string>("Issure"),
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration.GetValue<string>("Audiance"),
                    IssuerSigningKey = MySK
                };
            });
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                await AdminAccount.CreateAccountAdmin(services);
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
