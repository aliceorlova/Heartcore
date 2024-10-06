using Heartcore.Logic.ApiProviders;
using Heartcore.Logic.Managers;

namespace Heartcore.Logic
{
	public static class Dependencies
	{
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IContentManagementApiProvider, ContentManagementApiProvider>();
            services.AddScoped<IGraphQLApiProvider, GraphQLApiProvider>();
            services.AddScoped<IPublicApiProvider, PublicApiProvider>();
            services.AddScoped<IDataManager, DataManager>();

            return services;
        }
    }
}

