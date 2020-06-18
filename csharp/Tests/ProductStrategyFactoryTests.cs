using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp.ProductStrategies;
using NUnit.Framework;
using Shouldly;

namespace csharp.Tests
{
    [TestFixture]
    public class ProductStrategyFactoryTests
    {
        private ProductStrategyFactory _productStrategyFactory;

        [SetUp]
        public void SetUp()
        {
            _productStrategyFactory = new ProductStrategyFactory();
        }

        [Test]
        public void InstantiateDefaultProduct()
        {
            var strategy = _productStrategyFactory.Instantiate(new Item() {Name = "DDDD"});

            strategy.ShouldBeOfType<DefaultStrategy>();
        }


        [Test]
        public void InstantiateAgedBrieStrategy()
        {
            var strategy = _productStrategyFactory.Instantiate(new Item() { Name = "Aged Brie" });

            strategy.ShouldBeOfType<AgedBrieQualityUpdateStrategy>();
        }


        [Test]
        public void InstantiateConcertStrategy()
        {
            var strategy = _productStrategyFactory.Instantiate(new Item() { Name = "Backstage passes to a TAFKAL80ETC concert" });

            strategy.ShouldBeOfType<ConcertProductQualityUpdateStrategy>();
        }

        [Test]
        public void InstantiateSulfuraStrategy()
        {
            var strategy = _productStrategyFactory.Instantiate(new Item() { Name = "Sulfuras, Hand of Ragnaros" });

            strategy.ShouldBeOfType<SulfurasQualityUpdateStrategy>();
        }       
        [Test]
        public void InstantiateConjuredStrategy()
        {
            var strategy = _productStrategyFactory.Instantiate(new Item() { Name = "Conjured" });

            strategy.ShouldBeOfType<ConjuredProductQualityItemStrategy>();
        }
    }
}
