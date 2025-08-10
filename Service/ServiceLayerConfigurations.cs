using Microsoft.Extensions.DependencyInjection;
using Service.CoreServices;
using Domain.Contracts;

namespace Service
{
	public static class ServiceLayerConfigurations
	{
		public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
		{
			services.AddScoped<ILoggingService, LoggingService>();
			services.AddScoped<IChatService, ChatService>();
			return services;
		}
	}
}
