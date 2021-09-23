namespace UrlMapper.Domain.Objects.Pages
{
    public interface IWebPage : IPage
    {
        IMobilePage ToMobilePage();
    }
}