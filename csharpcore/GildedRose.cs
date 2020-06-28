using System.Collections.Generic;

namespace csharpcore
{

    public interface IQualityItemCalculator
    {
        void UpdateQuality(Item item);
    }

    public class QualityItemCalculatorFactory
    {
        public IQualityItemCalculator Instantiate(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return new SulfurasQualityItemCalculator();

            if (item.Name == "Aged Brie")
                return new BrieQualityCalculator();

            return null;
        }
    }

    public class BrieQualityCalculator : IQualityItemCalculator
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

    public class SulfurasQualityItemCalculator : IQualityItemCalculator
    {
        public void UpdateQuality(Item item)
        {
        }
    }

    public class GildedRose
    {
        private readonly IList<Item> _items;
        private readonly QualityItemCalculatorFactory _factory;

        public GildedRose(IList<Item> Items)
        {
            this._items = Items;
            _factory = new QualityItemCalculatorFactory();
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
                UpdateQuality(_items[i]);
        }

        private void UpdateQuality(Item item)
        {
            var qualityCalculator = _factory.Instantiate(item);
            if (qualityCalculator != null)
            {
                qualityCalculator.UpdateQuality(item);
                return;
            }

            if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 1;
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
                else
                {
                    item.Quality = item.Quality - item.Quality;
                }
            }
        }
    }
}
