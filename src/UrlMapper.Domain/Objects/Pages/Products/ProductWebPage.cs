using System.Collections.Generic;
using UrlMapper.Domain.Service.RouteHandlers.Web;

namespace UrlMapper.Domain.Objects.Pages.Products
{
    public class ProductWebPage : IProductWebPage
    {
        readonly List<IProductOption> options;
        private ProductWebPage(long contentId)
        {
            ContentId = contentId;
            options = new List<IProductOption>();
        }

        private string BrandNameOrCategoryName { get; set; }
        private string ProductName { get; set; }
        public long BoutiqueId { get; set; }
        public long MerchantId { get; set; }
        public long ContentId { get; }


        public IMobilePage ToMobilePage()
        {
            var res = new ProductMobilePage.Builder(ContentId);
            foreach (var option in options)
            {
                option.AddOnForProductMobilePage(res);
            }
            return res.Build();
        }

        public Route GetRoute()
        {
            var product = new Product(ContentId, "name");
            var productSegment = new ProductSegmentParser();
            var productRoute = productSegment.Build(product);

            var route = Route.Create()
                .AddSegment("brand")
                .AddSegment(productRoute);

            foreach (var option in options)
            {
                option.AddOnForRoute(route);
            }


            return route;
        }

        public class Builder
        {
            private readonly ProductWebPage page;

            public Builder(long contentId)
            {
                page = new ProductWebPage(contentId);
            }
            public void WithBrandOrCategoryName(string brandOrCategoryName)
            {
                page.BrandNameOrCategoryName = brandOrCategoryName;
            }

            public void WithProductName(string productName)
            {
                page.ProductName = productName;
            }

            public void WithMerchantId(long merchantId)
            {
                page.options.Add(new ProductMerchant(merchantId));
            }

            internal void WithBoutiqueId(long boutiqueId)
            {
                page.options.Add(new ProductBoutique(boutiqueId));
            }

            public ProductWebPage Build()
            {
                return page;
            }

         
        }
    }
}