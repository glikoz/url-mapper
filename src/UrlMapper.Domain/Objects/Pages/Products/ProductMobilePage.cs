namespace UrlMapper.Domain.Objects.Pages.Products
{
    public class ProductMobilePage : IMobilePage
    {
        private const string Page = "Page";
        private const string PageType = "Product";

        private ProductMobilePage(long contentId)
        {
            ContentId = contentId;
        }

        public long CampaignId { get; set; }
        public long MerchantId { get; set; }

        public long ContentId { get; }

        public IWebPage ToWebPage()
        {
            var builder = new ProductWebPage.Builder(ContentId);

            if (CampaignId != default)
                builder.WithBoutiqueId(CampaignId);
            if (MerchantId != default)
                builder.WithMerchantId(MerchantId);

            return builder.Build();
        }

        public Route GetRoute()
        {
            var routeBuilder = Route.Create().AddQueryParam(Page, PageType);

            routeBuilder.AddQueryParam(nameof(ContentId), ContentId);
            if (CampaignId != default)
                routeBuilder.AddQueryParam(nameof(CampaignId), CampaignId);
            if (MerchantId != default)
                routeBuilder.AddQueryParam(nameof(MerchantId), MerchantId);

            return routeBuilder;
        }

        public class Builder
        {
            private readonly ProductMobilePage page;

            public Builder(long contentId)
            {
                page = new ProductMobilePage(contentId);
            }

            public void WithCampaignId(long campaignId)
            {
                page.CampaignId = campaignId;
            }

            public void WithMerchantId(long merchantId)
            {
                page.MerchantId = merchantId;
            }

            public ProductMobilePage Build()
            {
                return page;
            }
        }
    }
}