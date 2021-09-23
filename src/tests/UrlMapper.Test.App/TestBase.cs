using Microsoft.Extensions.DependencyInjection;
using UrlMapper.Domain.Repository;
using UrlMapper.Domain.Repository.InMemory;
using UrlMapper.Domain.Service;
using UrlMapper.Domain.Service.RouteHandlers;
using UrlMapper.Domain.Service.UrlBuilders;

namespace UrlMapper.Test.App
{
    public class TestBase
    {
        public TestBase()
        {
            var services = new ServiceCollection();
            services.AddSingleton<WebMapper>();
            services.AddSingleton<WebRouteHandler>();
            services.AddSingleton<WebUrlBuilder>();
            services.AddSingleton<MobileUrlBuilder>();
            services.AddSingleton(typeof(IReadRepository<>), typeof(InMemoryRepository<>));
            services.AddSingleton(typeof(IWriteRepository<>), typeof(InMemoryRepository<>));
            ServiceProvider = services.BuildServiceProvider();
        }

        protected ServiceProvider ServiceProvider { get; }
    }
}