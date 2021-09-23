using UrlMapper.Domain.Exceptions;
using UrlMapper.Domain.Service.UriParsers;
using Xunit;

namespace UrlMapper.Test.App.Tests
{
    public class ExceptionTests
    {
        [Fact]
        public void WhenWebHostIsWrongThrowsArgumentDomainException()
        {
            var webUrl = "https://w2.oz.com";
            Assert.Throws<ArgumentDomainException>(()=>new WebUri(webUrl));
        }

        [Fact]
        public void WhenWebSchemaIsWrongThrowsArgumentDomainException()
        {
            var webUrl = "http://www.oz.com";
            Assert.Throws<ArgumentDomainException>(() => new WebUri(webUrl));
        }

        [Fact]
        public void WhenMobileHostIsWrongThrowsArgumentDomainException()
        {
            var webUrl = "oz://www.oz.com";
            Assert.Throws<ArgumentDomainException>(() => new MobileUri(webUrl));
        }
        [Fact]
        public void WhenMobileSchemeIsWrongThrowsArgumentDomainException()
        {
            var webUrl = "http://oz";
            Assert.Throws<ArgumentDomainException>(() => new MobileUri(webUrl));
        }

        
        
    }
}
