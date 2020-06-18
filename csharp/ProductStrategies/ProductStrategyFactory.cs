namespace csharp
{
    public class ProductStrategyFactory
    {
        public IProductQualityUpdateStrategy Instantiate(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return new SulfurasQualityUpdateStrategy();

            if (item.Name == "Aged Brie")
                return new AgedBrieQualityUpdateStrategy();

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                return new ConcertProductQualityUpdateStrategy();

            return new DefaultStrategy();
        }
    }
}