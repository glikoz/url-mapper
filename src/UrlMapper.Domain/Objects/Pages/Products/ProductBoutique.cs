namespace UrlMapper.Domain.Objects.Pages.Products
{
    public class ProductBoutique : IProductOption
    {
        private readonly long boutiqueId;

        public ProductBoutique(long boutiqueId)
        {
            this.boutiqueId = boutiqueId;
        }

        public void AddOnForProductMobilePage(ProductMobilePage.Builder productMobilePageBuilder)
        {
            productMobilePageBuilder.WithCampaignId(boutiqueId);
        }

        public void AddOnForRoute(Route route)
        {
            route.AddQueryParam("boutiqueId", boutiqueId);
        }
    }
}