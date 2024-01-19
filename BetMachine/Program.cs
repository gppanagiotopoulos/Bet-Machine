using BetMachine.Extensions;
using BetMachine.Helpers;
using BetMachine.Service.Extensions;
using Microsoft.AspNetCore.Session;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

namespace BetMachine
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //Repositories
            builder.Services.AddRepositoryServices(builder.Configuration);

            //Cors
            builder.Services.AddCors();

            //Add newtonsoft for timespan
            builder.Services.AddMvc().AddNewtonsoftJson(options =>
                options.SerializerSettings.Converters.Add(new StringEnumConverter()));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //Configure Swagger Enums as strings with  Newtonsoft Support
            builder.Services.AddSwaggerGenNewtonsoftSupport();

            //Add Automapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            //Add Swagger generator plus options for timespan
            builder.Services.AddSwaggerGen(options =>
            {
                options.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("00:00:00")
                });
            });

            var app = builder.Build();


            //Auto Migrate
            await app.MigrateDatabaseAsync();

            //Add middleware exception handler

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            await app.RunAsync();
        }
    }
}