using CsvHelper.Configuration;

namespace UrlMapper.Test.App.Entity
{
    internal class MapTestDataMapper : ClassMap<MapTestData>
    {
        public MapTestDataMapper()
        {
            Map(m => m.Request);
            Map(m => m.ResponseResult);
            Map(m => m.Description);
            Map(m => m.ResponseError);
        }
    }
}