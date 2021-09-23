namespace UrlMapper.Domain.Service.UriParsers
{
    public class MobileUri : SmartUri
    {
        public MobileUri(string uri) : base(uri)
        {
        }

        protected override string RequiredScheme => "oz";

        protected override string RequiredAuthority => "";
    }
}