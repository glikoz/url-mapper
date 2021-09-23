using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlMapper.Domain.Objects
{
    public class Route
    {
        public static readonly Route Empty = new();
        public readonly Dictionary<string, string> Parameters;

        private Route()
        {
            Segments = new List<string>();
            Parameters = new Dictionary<string, string>();
        }

        public List<string> Segments { get; }

        public static Route Create()
        {
            return new Route();
        }

        public Route AddSegments(IEnumerable<string> segments)
        {
            foreach (var segment in segments) Segments.Add(segment);
            return this;
        }

        public Route AddSegment(string segment)
        {
            Segments.Add(segment);
            return this;
        }

        public Route AddQueryParam(string key, object value)
        {
            Parameters.TryAdd(key, value.ToString());

            return this;
        }

        public bool TryGetStringParameter(string parameterName, out string result)
        {
            result = default;
            if (!Parameters.TryGetValue(parameterName, out var value))
                return false;

            result = value;
            return true;
        }

        public bool TryGetLongParameter(string parameterName, out long result)
        {
            result = default;
            if (!Parameters.TryGetValue(parameterName, out var value))
                return false;

            if (!long.TryParse(value, out var longResult))
                return false;

            result = longResult;
            return true;
        }

        public string GetRoutePath()
        {
            var route = string.Empty;
            if (Segments.Count > 0)
                route += string.Join('/', Segments);

            if (Parameters.Count > 0)
                route += "?" + string.Join('&',
                    Parameters.Select(p => $"{HttpUtility.UrlEncode(p.Key)}={HttpUtility.UrlEncode(p.Value)}"));

            return route;
        }

        public override int GetHashCode()
        {
            var s=string.Join(string.Empty, Segments) + string.Join(string.Empty, Parameters.Select(p => p.Key + p.Value));
            return s.GetHashCode();
        }

    }
}