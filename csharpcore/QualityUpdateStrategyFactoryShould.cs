using System;
using System.Collections.Generic;
using System.Text;
using csharpcore.QualityUpdate;
using Shouldly;
using Xunit;

namespace csharpcore
{
    public class QualityUpdateStrategyFactoryShould
    {
        private QualityUpdateStrategyFactory _factory;

        public QualityUpdateStrategyFactoryShould()
        {
            _factory = new QualityUpdateStrategyFactory();
        }

        [Fact]
        public void InstantiateDefaultProduct()
        {
            var strategy = _factory.Instantiate(new Item() { Name = "DDDD" });

            strategy.ShouldBeOfType<DefaultQualityUpdateStrategy>();
        }

        [Fact]
        public void InstantiateAgedBrieStrategy()
        {
            var strategy = _factory.Instantiate(new Item() { Name = "Aged Brie" });

            strategy.ShouldBeOfType<BrieQualityUpdateStrategy>();
        }

        [Fact]
        public void InstantiateConcertStrategy()
        {
            var strategy = _factory.Instantiate(new Item() { Name = "Backstage passes to a TAFKAL80ETC concert" });

            strategy.ShouldBeOfType<ConcertQualityUpdateStrategy>();
        }

        [Fact]
        public void InstantiateSulfuraStrategy()
        {
            var strategy = _factory.Instantiate(new Item() { Name = "Sulfuras, Hand of Ragnaros" });

            strategy.ShouldBeOfType<SulfurasQualityUpdateStrategy>();
        }

        [Fact]
        public void InstantiateConjuredStrategy()
        {
            var strategy = _factory.Instantiate(new Item() { Name = "Conjured" });

            strategy.ShouldBeOfType<ConjuredQualityUpdateStrategy>();
        }
    }
}
