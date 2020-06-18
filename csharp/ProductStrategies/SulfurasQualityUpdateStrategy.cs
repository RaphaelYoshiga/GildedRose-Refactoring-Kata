namespace csharp.ProductStrategies
{
    public class SulfurasQualityUpdateStrategy : IProductQualityUpdateStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.Quality = 80;
        }
    }
}