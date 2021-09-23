using System.Collections.Generic;
using System.Linq;
using UrlMapper.Domain.Objects;
using UrlMapper.Domain.Objects.Pages;
using UrlMapper.Domain.Objects.Pages.Homes;
using UrlMapper.Domain.Objects.Pages.Products;
using UrlMapper.Domain.Objects.Pages.Searches;
using UrlMapper.Domain.Service.RouteHandlers.Exceptions;
using UrlMapper.Domain.Service.RouteHandlers.Web;

namespace UrlMapper.Domain.Service.RouteHandlers
{
    public class WebRouteHandler
    {
        private readonly List<IRouteHandler<IWebPage>> resolvers;

        public WebRouteHandler()
        {
            resolvers = new List<IRouteHandler<IWebPage>>
            {
                new ProductWebRouteHandler(),
                new SearchWebRouteHandler()
            };
        }

        private IWebPage Fallback(Route route)
        {
            return new HomeWebPage(route.GetRoutePath());
        }

        public IWebPage Resolve(Route route)
        {
            var matches = resolvers.Select(p => p.Handle(route)).Where(p => p.Matched).ToArray();

            if (matches.Length == 1)
                return matches[0].Result;
            if (matches.Length > 1) throw new AmbiguousRouteMapException();

            //Fallback
            return Fallback(route);
        }
    }
}