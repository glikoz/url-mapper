namespace UrlMapper.Domain.Service.UriParsers
{
    public class WebUri : SmartUri
    {
        public WebUri(string uri) : base(uri)
        {
        }

        protected override string RequiredScheme => "https";

        protected override string RequiredAuthority => "www.oz.com";
    }
}