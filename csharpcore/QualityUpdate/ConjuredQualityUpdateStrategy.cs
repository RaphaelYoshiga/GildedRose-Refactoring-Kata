namespace csharpcore.QualityUpdate
{
    public class ConjuredQualityUpdateStrategy : IQualityUpdateStrategy
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