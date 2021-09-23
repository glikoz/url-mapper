using UrlMapper.Domain.Objects.Pages;

namespace UrlMapper.Domain.Service.RouteHandlers
{
    public class MatchResult<TPage> where TPage : IPage
    {
        public static readonly MatchResult<TPage> NotFound = new();

        private MatchResult(TPage page)
        {
            Result = page;
            Matched = true;
        }

        private MatchResult(string errorMessage)
        {
            Matched = true;
            ErrorMessage = errorMessage;
        }

        private MatchResult()
        {
        }

        public bool Matched { get; }
        private string ErrorMessage { get;  }
        public TPage Result { get; }

        public static MatchResult<TPage> Success(TPage page)
        {
            return new MatchResult<TPage>(page);
        }

        public static MatchResult<TPage> Fail(string errorMessage)
        {
            return new MatchResult<TPage>(errorMessage);
        }
    }
}