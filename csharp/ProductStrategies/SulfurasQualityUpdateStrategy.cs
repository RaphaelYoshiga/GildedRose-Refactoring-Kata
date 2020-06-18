namespace csharp
{
    public class SulfurasQualityUpdateStrategy : IProductQualityUpdateStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.Quality = 80;
        }
    }
}