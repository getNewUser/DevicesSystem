using DevicesSystem.Api.Serialization;
using DevicesSystem.Infrastructure.Extensions;
using DevicesSystem.Infrastructure.Persistance;
using DeviceSystem.Application.Extensions;
using Hangfire;
using Microsoft.Extensions.Options;

namespace DevicesSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new TurnableSingleConverter());
                options.SerializerSettings.Converters.Add(new TurnableCollectionConverter());

            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services
                .AddApplication()
                .AddInfrastructure();



            var app = builder.Build();

            app.UseHangfireDashboard();

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