using Carly.App;
using Carly.App.Features.Vehicles.AddNew;
using Carter;
using Carly.Infrastructure;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http.Features;

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
            builder.Services.AddProblemDetails(options =>
            {
                options.CustomizeProblemDetails = context =>
                {
                    context.ProblemDetails.Instance =
                    $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
                    context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);

                    var activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
                    context.ProblemDetails.Extensions.TryAdd("traceId", activity?.Id);
                };
            });
            builder.Services.AddCarter();
            builder.Services.AddInfrastructure();

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();

            // Configure the HTTP request pipeline.

            app.UseCors("MyPolicy");
            app.UseInfrastructure();
            app.UseHttpsRedirection();


            app.MapCarter();

            app.Run();
        }
    }
}
