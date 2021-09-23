namespace UrlMapper.Domain.Objects.Pages.Products
{
    public interface IProductOption
    {
        void AddOnForRoute(Route route);
        void AddOnForProductMobilePage(ProductMobilePage.Builder productMobilePageBuilder);
    }
}