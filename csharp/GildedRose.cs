using System.Collections.Generic;
using csharp.ProductStrategies;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        private ProductStrategyFactory _productStrategyFactory;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            _productStrategyFactory = new ProductStrategyFactory();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateQuality(item);
            }
        }

        private void UpdateQuality(Item item)
        {
            var strategy = _productStrategyFactory.Instantiate(item);
            strategy.UpdateQuality(item);
        }
    }
}
