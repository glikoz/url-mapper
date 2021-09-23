using System;
using System.Runtime.Serialization;

namespace UrlMapper.Domain.Exceptions
{
    [Serializable]
    public class ArgumentDomainException : DomainException
    {
        public ArgumentDomainException()
        {
        }

        public ArgumentDomainException(string message) : base(message)
        {
        }

        public ArgumentDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArgumentDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}