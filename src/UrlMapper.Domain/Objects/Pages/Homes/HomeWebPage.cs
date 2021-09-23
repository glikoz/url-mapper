namespace UrlMapper.Domain.Objects.Pages.Homes
{
    internal class HomeWebPage : IWebPage
    {
        public HomeWebPage(string url)
        {
            Url = url;
        }

        private string Url { get; }

        public Route GetRoute()
        {
            return Route.Empty;
        }

        public IMobilePage ToMobilePage()
        {
            return new HomeMobilePage(Url);
        }
    }
}