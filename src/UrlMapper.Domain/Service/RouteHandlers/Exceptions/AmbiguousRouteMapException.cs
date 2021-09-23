using System;
using System.Runtime.Serialization;
using UrlMapper.Domain.Exceptions;

namespace UrlMapper.Domain.Service.RouteHandlers.Exceptions
{
    [Serializable]
    public class AmbiguousRouteMapException : ArgumentDomainException
    {
        public AmbiguousRouteMapException()
        {
        }

        public AmbiguousRouteMapException(string message) : base(message)
        {
        }

        public AmbiguousRouteMapException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AmbiguousRouteMapException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}