using csharpcore.QualityUpdate;
using Shouldly;
using Xunit;

namespace csharpcore.Tests
{
    public class ConjuredQualityUpdateStrategyShould
    {
        private readonly ConjuredQualityUpdateStrategy _updateStrategy;

        public ConjuredQualityUpdateStrategyShould()
        {
            _updateStrategy = new ConjuredQualityUpdateStrategy();
        }

        [Fact]
        public void ItemDegradesTwiceAsFast()
        {
            var item = new Item() { Quality = 10, SellIn = 1 };

            _updateStrategy.UpdateQuality(item);

            item.Quality.ShouldBe(8);
            item.SellIn.ShouldBe(0);
        }

        [Fact]
        public void ItemDegradesTwiceAsFast2()
        {
            var item = new Item() { Quality = 12, SellIn = 2 };

            _updateStrategy.UpdateQuality(item);

            item.Quality.ShouldBe(10);
            item.SellIn.ShouldBe(1);
        }

        [Fact]
        public void ItemDegrades4TimesAsFastPastTheDate()
        {
            var item = new Item() { Quality = 12, SellIn = 0 };

            _updateStrategy.UpdateQuality(item);

            item.Quality.ShouldBe(8);
            item.SellIn.ShouldBe(-1);
        }
    }


}
