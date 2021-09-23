using System.Text.RegularExpressions;
using UrlMapper.Domain.Objects.Pages.Products;

namespace UrlMapper.Domain.Service.RouteHandlers.Web
{
    public class ProductSegmentParser
    {
        private static readonly Regex Pattern = new(@"(.*)-p-(\d+$)", RegexOptions.Compiled | RegexOptions.Singleline);

        public Product Parse(string segment)
        {
            var match = Pattern.Match(segment);
            if (match.Groups.Count < 3)
                return Product.Empty;

            return new Product(long.Parse(match.Groups[2].Value), match.Groups[1].Value);
        }

        public string Build(Product product)
        {
            return $"{product.Name}-p-{product.Id}";
        }
    }
}