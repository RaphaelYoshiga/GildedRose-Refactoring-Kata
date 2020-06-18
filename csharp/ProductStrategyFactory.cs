namespace csharp
{
    public class ProductStrategyFactory
    {
        public IProductQualityUpdateStrategy Instantiate(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return new SulfurasQualityUpdateStrategy();
            }

            if (item.Name == "Aged Brie")
            {
                return new AgedBrieQualityUpdateStrategy();
            }

            return null;
        }
    }
}