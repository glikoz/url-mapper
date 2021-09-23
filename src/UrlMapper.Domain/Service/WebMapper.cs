using System.Threading.Tasks;
using UrlMapper.Domain.Objects.Pages;
using UrlMapper.Domain.Repository;
using UrlMapper.Domain.Service.RouteHandlers;
using UrlMapper.Domain.Service.UriParsers;
using UrlMapper.Domain.Service.UrlBuilders;

namespace UrlMapper.Domain.Service
{
    public class WebMapper
    {
        private readonly WebRouteHandler webRouteHandler;
        private readonly MobileUrlBuilder mobileUrlBuilder;
        private readonly IWriteRepository<WebEntity> writeRepository;

        public WebMapper(WebRouteHandler webRouteHandler,MobileUrlBuilder mobileUrlBuilder,  IWriteRepository<WebEntity> writeRepository) 
        {
            this.webRouteHandler = webRouteHandler;
            this.mobileUrlBuilder = mobileUrlBuilder;
            this.writeRepository = writeRepository;
        }

        private  IMobilePage Convert(IWebPage page)
        {
            return page.ToMobilePage();
        }

        public async Task<string> Map(string url)
        {
            var uri = GetUri(url);
            var page = webRouteHandler.Resolve(uri.Route);
            var targetPage = Convert(page);
            var route = targetPage.GetRoute();
            var res= mobileUrlBuilder.GetUrl(route);
            await writeRepository.StoreAsync(url, res);
            return res;
        }

        private SmartUri GetUri(string url)
        {
            return new WebUri(url);
        }
    }
}