using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace csharp
{
    [TestFixture]
    public class ConjuredItemsTests
    {

        [Test]
        public void ConjuredItemDegradesTwiceAsFast()
        {
            var item = new Item() { Quality = 10, SellIn = 1 };
            new ConjuredProductQualityItemStrategy().UpdateQuality(item);

            item.Quality.ShouldBe(8);
            item.SellIn.ShouldBe(0);
        }

        [Test]
        public void ConjuredItemDegradesTwiceAsFast2()
        {
            var item = new Item() { Quality = 12, SellIn = 2 };
            new ConjuredProductQualityItemStrategy().UpdateQuality(item);

            item.Quality.ShouldBe(10);
            item.SellIn.ShouldBe(1);
        }

        [Test]
        public void ConjuredItemDegrades4TimesAsFastPastTheDate()
        {
            var item = new Item() { Quality = 12, SellIn = 0 };
            new ConjuredProductQualityItemStrategy().UpdateQuality(item);

            item.Quality.ShouldBe(8);
            item.SellIn.ShouldBe(-1);
        }
    }
}
