
using Presistence;
using Serilog;
using Service;
namespace Chatty
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddPresistenceConfig(builder.Configuration);// Custom extension method to add persistence services
			builder.Services.AddServiceConfiguration();
			builder.Services.AddControllers();
			builder.Host.UseSerilog((context, configuration) =>
			configuration.ReadFrom.Configuration(context.Configuration)
			);
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseSerilogRequestLogging();
			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
