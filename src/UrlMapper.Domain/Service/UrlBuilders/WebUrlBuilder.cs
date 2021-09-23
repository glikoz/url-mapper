using System;
using System.Web;
using UrlMapper.Domain.Objects;

namespace UrlMapper.Domain.Service.UrlBuilders
{
    public class WebUrlBuilder : IUrlBuilder
    {
        public string GetUrl(Route route)
        {
            var uriBuilder = new UriBuilder
            {
                Scheme = "https",
                Host = "www.oz.com",
                Path = string.Join('/', route.Segments)
            };

            var parameters = HttpUtility.ParseQueryString(string.Empty);
            foreach (var parameter in route.Parameters) parameters.Add(parameter.Key, parameter.Value);

            uriBuilder.Query = parameters.ToString() ?? string.Empty;

            return uriBuilder.Uri.AbsoluteUri.TrimEnd('/');
        }
    }
}