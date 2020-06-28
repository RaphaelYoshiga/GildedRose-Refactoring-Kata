using System.Collections.Generic;
using csharpcore.QualityUpdate;

namespace csharpcore
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        private readonly QualityUpdateStrategyFactory _factory;

        public GildedRose(IList<Item> Items)
        {
            this._items = Items;
            _factory = new QualityUpdateStrategyFactory();
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
                UpdateQuality(_items[i]);
        }

        private void UpdateQuality(Item item)
        {
            var qualityUpdateStrategy = _factory.Instantiate(item);
            qualityUpdateStrategy.UpdateQuality(item);
        }
    }
}
