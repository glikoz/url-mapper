namespace UrlMapper.Domain.Objects.Pages.Searches
{
    public class SearchWebPage : IWebPage
    {
        public SearchWebPage(string searchText)
        {
            SearchText = searchText;
        }

        private string SearchText { get; }

        public Route GetRoute()
        {
            return Route.Create()
                .AddSegment("sr")
                .AddQueryParam("q", SearchText);
        }

        public IMobilePage ToMobilePage()
        {
            return new SearchMobilePage(SearchText);
        }
    }
}