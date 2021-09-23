using UrlMapper.Domain.Objects.Pages.Products;
using UrlMapper.Domain.Service.RouteHandlers.Web;
using Xunit;

namespace UrlMapper.Test.App.Tests
{
    public class SegmentParsers
    {
        [Theory]
        [InlineData("watch-p-1925865", 1925865, "watch")]
        [InlineData("watch-p-1a925865", 0, null)]
        [InlineData("watch-p-", 0, null)]
        [InlineData("uy-p-watch-p-1925865", 1925865, "uy-p-watch")]
        [InlineData("uy-p-23watch-p-1925865", 1925865, "uy-p-23watch")]
        public void SegmentParse(string segment, long id, string name)
        {
            var p = new ProductSegmentParser().Parse(segment);
            Assert.Equal(id, p.Id);
            Assert.Equal(name, p.Name);
        }
    }
}