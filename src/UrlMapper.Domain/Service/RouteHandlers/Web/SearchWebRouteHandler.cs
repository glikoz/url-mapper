using UrlMapper.Domain.Objects;
using UrlMapper.Domain.Objects.Pages;
using UrlMapper.Domain.Objects.Pages.Searches;

namespace UrlMapper.Domain.Service.RouteHandlers.Web
{
    public class SearchWebRouteHandler : IRouteHandler<IWebPage>
    {
        public MatchResult<IWebPage> Handle(Route route)
        {
            if (route.Segments.Count == 1 && route.Segments[0] == "sr")
            {
                if (!route.TryGetStringParameter("q", out var query))
                    return MatchResult<IWebPage>.Fail("Query Parameter Could Not Be Resolved");
                return MatchResult<IWebPage>.Success(new SearchWebPage(query));
            }

            return MatchResult<IWebPage>.NotFound;
        }
    }
}