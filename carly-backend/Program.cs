using Carly.App;
using Carter;
using Microsoft.OpenApi.Models;

namespace Carly.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Description = "Carly",
                    Version = "v1",
                    Title = "A Carly API"
                });

            });


            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            builder.Services.AddApp();
            builder.Services.AddCarter();

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();

            // Configure the HTTP request pipeline.

            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();


            app.MapCarter();

            app.Run();
        }
    }
}
