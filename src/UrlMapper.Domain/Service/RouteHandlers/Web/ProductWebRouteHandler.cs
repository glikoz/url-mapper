using UrlMapper.Domain.Objects;
using UrlMapper.Domain.Objects.Pages;
using UrlMapper.Domain.Objects.Pages.Products;

namespace UrlMapper.Domain.Service.RouteHandlers.Web
{
    public class ProductWebRouteHandler : IRouteHandler<IWebPage>
    {
        private readonly ProductSegmentParser productSegmentParser;

        public ProductWebRouteHandler()
        {
            productSegmentParser = new ProductSegmentParser();
        }


        public MatchResult<IWebPage> Handle(Route route)
        {
            if (route.Segments.Count == 2)
            {
                var brandName = route.Segments[0];

                var product = productSegmentParser.Parse(route.Segments[1]);

                if (product == Product.Empty)
                    return MatchResult<IWebPage>.NotFound;

                var builder = new ProductWebPage.Builder(product.Id);
                builder.WithBrandOrCategoryName(brandName);
                builder.WithProductName(product.Name);

                if (route.TryGetLongParameter("boutiqueId", out var boutiqueId))
                    builder.WithBoutiqueId(boutiqueId);

                if (route.TryGetLongParameter("merchantId", out var merchantId))
                    builder.WithMerchantId(merchantId);

                return MatchResult<IWebPage>.Success(builder.Build());
            }

            return MatchResult<IWebPage>.NotFound;
        }
    }
}