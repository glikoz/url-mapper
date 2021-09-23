namespace UrlMapper.Domain.Objects.Pages
{
    public interface IMobilePage : IPage
    {
        IWebPage ToWebPage();
    }
}