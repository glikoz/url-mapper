using System;
using System.Web;
using UrlMapper.Domain.Objects;

namespace UrlMapper.Domain.Service.UrlBuilders
{
    public class MobileUrlBuilder : IUrlBuilder
    {
        public string GetUrl(Route route)
        {
            var uriBuilder = new UriBuilder
            {
                Scheme = "oz",
                Host = ""
            };
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            foreach (var parameter in route.Parameters) parameters.Add(parameter.Key, parameter.Value);

            uriBuilder.Query = parameters.ToString() ?? string.Empty;
            return uriBuilder.Uri.AbsoluteUri.Replace("oz:/", "oz://");
        }
    }
}