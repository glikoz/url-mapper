namespace UrlMapper.Domain.Objects.Pages.Searches
{
    public class SearchMobilePage : IMobilePage
    {
        public SearchMobilePage(string searchText)
        {
            SearchText = searchText;
        }

        private string SearchText { get; }

        public Route GetRoute()
        {
            return Route.Create().AddQueryParam("Page", "Search").AddQueryParam("Query", SearchText);
        }

        public IWebPage ToWebPage()
        {
            return new SearchWebPage(SearchText);
        }

    }
}