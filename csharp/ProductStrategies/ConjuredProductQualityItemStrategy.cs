using csharp.ProductStrategies;

namespace csharp
{
    public class ConjuredProductQualityItemStrategy : IProductQualityUpdateStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.SellIn > 0)
                item.Quality -= 2;
            else
                item.Quality -= 4;

            item.SellIn--;
        }
    }
}