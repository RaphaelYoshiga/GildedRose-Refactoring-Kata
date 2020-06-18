namespace csharp
{
    internal class AgedBrieQualityUpdateStrategy : IProductQualityUpdateStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.SellIn > 0)
                item.Quality++;
            else
                item.Quality += 2;

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
            
            item.SellIn--;
        }
    }
}