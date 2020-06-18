namespace csharp
{
    public class DefaultStrategy : IProductQualityUpdateStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality > 0)
                item.Quality--;

            item.SellIn = item.SellIn - 1;

            if (item.SellIn >= 0) 
                return;

            if (item.Quality > 0)
                item.Quality --;
        }
    }
}