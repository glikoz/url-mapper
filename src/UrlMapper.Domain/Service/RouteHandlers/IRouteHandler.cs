using UrlMapper.Domain.Objects;
using UrlMapper.Domain.Objects.Pages;

namespace UrlMapper.Domain.Service.RouteHandlers
{
    public interface IRouteHandler<TPage> where TPage : IPage
    {
        MatchResult<TPage> Handle(Route route);
    }
}