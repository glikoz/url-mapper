using System.Text.RegularExpressions;
using System.Web;
using UrlMapper.Domain.Exceptions;
using UrlMapper.Domain.Objects;

namespace UrlMapper.Domain.Service.UriParsers
{
    public abstract class SmartUri
    {
        /// <summary>
        ///     https://datatracker.ietf.org/doc/html/rfc3986#appendix-B
        /// </summary>
        private static readonly Regex Parser = new(@"^(([^:/?#]+):)?(//([^/?#]*))?([^?#]*)(\?([^#]*))?(#(.*))?",
            RegexOptions.Compiled | RegexOptions.Singleline);

        protected SmartUri(string uri)
        {
            AbsoluteUri = uri;
            var match = Parser.Match(uri);

            Scheme = match.Groups[2].Value;
            Authority = match.Groups[4].Value;

            if (Scheme != RequiredScheme)
                throw new ArgumentDomainException($"{Scheme} is Invalid Scheme. Expected:{RequiredScheme}");

            if (Authority != RequiredAuthority)
                throw new ArgumentDomainException($"{Authority} is Invalid Authority. Expected:{RequiredAuthority}");

            var path = HttpUtility.UrlDecode(match.Groups[5].Value);
            path = path.TrimStart('/');
            path = path.TrimEnd('/');
            var segments = path.Split('/');
            Route = Route.Create().AddSegments(segments);

            var query = HttpUtility.UrlDecode(match.Groups[7].Value);
            foreach (var parameter in query.TrimEnd('/').Split('&'))
            {
                var keyValue = parameter.Split('=');
                if (keyValue.Length != 2)
                    continue;

                var key = keyValue[0];
                var value = keyValue[1];
                Route.AddQueryParam(key, value);
            }
        }

        public string Scheme { get; }
        public string Authority { get; }
        public Route Route { get; }
        public string AbsoluteUri { get; }
        protected abstract string RequiredScheme { get; }
        protected abstract string RequiredAuthority { get; }
    }
}