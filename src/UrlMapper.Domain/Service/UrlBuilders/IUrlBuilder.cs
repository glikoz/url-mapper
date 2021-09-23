using UrlMapper.Domain.Objects;

namespace UrlMapper.Domain.Service.UrlBuilders
{
    public interface IUrlBuilder
    {
        string GetUrl(Route route);
    }
}