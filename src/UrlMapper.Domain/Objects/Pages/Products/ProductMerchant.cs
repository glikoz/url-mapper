namespace UrlMapper.Domain.Objects.Pages.Products
{
    public class ProductMerchant : IProductOption
    {
        private readonly long merchantId;

        public ProductMerchant(long merchantId)
        {
            this.merchantId = merchantId;
        }

        public void AddOnForProductMobilePage(ProductMobilePage.Builder productMobilePageBuilder)
        {
            productMobilePageBuilder.WithMerchantId(merchantId);
        }

        public void AddOnForRoute(Route route)
        {
            route.AddQueryParam("merchantId", merchantId);

        }
    }
}