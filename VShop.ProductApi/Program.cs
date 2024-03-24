using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.Repositories;
using VShop.ProductApi.Services;

namespace VShop.ProductApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
    
        builder.Services.AddControllers().AddJsonOptions(options => 
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
        
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));
        
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IProductService, ProductService>();
        
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