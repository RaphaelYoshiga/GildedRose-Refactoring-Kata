using System.Collections.Generic;

namespace csharpcore
{

    public interface IQualityUpdateStrategy
    {
        void UpdateQuality(Item item);
    }



    public class BackstageQualityUpdateStrategy : IQualityUpdateStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.SellIn <= 0)
                item.Quality = 0;
            else if (item.SellIn <= 5)
                item.Quality += 3;
            else if (item.SellIn <= 10)
                item.Quality += 2;
            else
                item.Quality++;

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }

            item.SellIn--;
        }
    }

    public class BrieQualityUpdateStrategy : IQualityUpdateStrategy
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

    public class SulfurasQualityUpdateStrategy : IQualityUpdateStrategy
    {
        public void UpdateQuality(Item item)
        {
        }
    }

    public class DefaultQualityUpdateStrategy : IQualityUpdateStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality > 0)
                item.Quality = item.Quality - 1;

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0 && item.Quality > 0)
                item.Quality = item.Quality - 1;
        }
    }

    public class QualityUpdateStrategyFactory
    {
        public IQualityUpdateStrategy Instantiate(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return new SulfurasQualityUpdateStrategy();

            if (item.Name == "Aged Brie")
                return new BrieQualityUpdateStrategy();

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                return new BackstageQualityUpdateStrategy();

            return new DefaultQualityUpdateStrategy();
        }
    }

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
