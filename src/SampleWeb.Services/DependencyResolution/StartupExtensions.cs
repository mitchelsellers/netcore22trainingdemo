using SampleWeb.Services.Samples;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtensions
    {
        public static void RegisterDataServices(this IServiceCollection services)
        {
            //Add your stuff here!
            services.AddTransient<ISampleDataService, SampleDataService>();
        }
    }
}