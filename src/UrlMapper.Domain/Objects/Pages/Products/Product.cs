namespace UrlMapper.Domain.Objects.Pages.Products
{
    public class Product
    {
        public static readonly Product Empty = new(0, null);

        public Product(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; }
        public string Name { get; }
    }
}