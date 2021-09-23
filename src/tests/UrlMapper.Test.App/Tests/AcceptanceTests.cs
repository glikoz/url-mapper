using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UrlMapper.Domain.Service;
using UrlMapper.Test.App.Entity;
using UrlMapper.Test.App.Extensions;
using Xunit;

namespace UrlMapper.Test.App.Tests
{
    public class AcceptanceTests : TestBase
    {
        [Theory]
        [CsvData("weburl.csv")]
        public async Task WebUrl(MapTestData data)
        {
            var mapper = ServiceProvider.GetRequiredService<WebMapper>();
            var res = mapper.Map(data.Request);

            Assert.Equal(data.ResponseResult, await res);
        }

    }
}