using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stream.Server.Domain.Handlers;
using Stream.Server.Domain.Infra.Contexts;
using Stream.Server.Domain.Infra.Repositories;
using Stream.Server.Domain.Repositories;

namespace Stream.Server.Api.Helpers
{
    public static class DomainHelper
    {
        public static void AddContexts(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext, DataContext>(opt => opt.UseInMemoryDatabase("Server_Db"));
        }

        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<ServerHandler, ServerHandler>();
            services.AddTransient<VideoHandler, VideoHandler>();
            services.AddTransient<RecycleHandler, RecycleHandler>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IServerRepository, ServerRepository>();
            services.AddTransient<IVideoRepository, VideoRepository>();
            services.AddTransient<IRecycleRepository, RecycleRepository>();
        }
    }
}
