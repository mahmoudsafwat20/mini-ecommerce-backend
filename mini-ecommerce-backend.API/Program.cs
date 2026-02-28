
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using mini_ecommerce_backend.Domain.Interfaces;
using mini_ecommerce_backend.Domain.Interfaces.Repo;
using mini_ecommerce_backend.Infrastructure.Services;
using mini_ecommerce_backend.Presistance;
using mini_ecommerce_backend.Presistance.Repo;

namespace mini_ecommerce_backend.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

           builder.Services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"),
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Squad API", Version = "v1.0" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
            });
            builder.Services.AddScoped<ICreateOrder, CreateOrder>();
            builder.Services.AddScoped<ICreateProduct, CreateProduct>();
            builder.Services.AddScoped<IGetOrder, GetOrder>();
            builder.Services.AddScoped<IListProducts1, ListProducts>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repositories<>));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }
            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
