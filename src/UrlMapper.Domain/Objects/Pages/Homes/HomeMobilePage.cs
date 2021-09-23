namespace UrlMapper.Domain.Objects.Pages.Homes
{
    public class HomeMobilePage : IMobilePage
    {
        public HomeMobilePage(string url)
        {
            Url = url;
        }

        private string Url { get; }

        public Route GetRoute()
        {
            return Route.Create().AddQueryParam("Page", "Home");
        }

        public IWebPage ToWebPage()
        {
            return new HomeWebPage(Url);
        }
    }
}