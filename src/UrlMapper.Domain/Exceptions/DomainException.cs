using System;
using System.Runtime.Serialization;

namespace UrlMapper.Domain.Exceptions
{
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException()
        {
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DomainException(string userMessage, int errorCode, string userMessageCode = null, string message = null,
            Exception innerException = null) : base(message, innerException)
        {
            UserMessage = userMessage;
            ErrorCode = errorCode;
            UserMessageCode = userMessageCode;
        }

        public string UserMessage { get; set; }
        public int ErrorCode { get; set; }
        public string UserMessageCode { get; set; }
    }
}