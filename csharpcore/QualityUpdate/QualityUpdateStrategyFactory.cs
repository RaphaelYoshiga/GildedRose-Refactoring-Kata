namespace csharpcore.QualityUpdate
{
    public class QualityUpdateStrategyFactory
    {
        public IQualityUpdateStrategy Instantiate(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return new SulfurasQualityUpdateStrategy();

            if (item.Name == "Aged Brie")
                return new BrieQualityUpdateStrategy();

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                return new ConcertQualityUpdateStrategy();

            if (item.Name == "Conjured")
                return new ConjuredQualityUpdateStrategy();

            return new DefaultQualityUpdateStrategy();
        }
    }
}