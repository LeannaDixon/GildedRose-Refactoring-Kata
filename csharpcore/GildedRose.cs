using System;
using System.Collections.Generic;
using System.Linq;

namespace csharpcore
{
    delegate void QualityStrategy(Item item);
    delegate void QualityStrategyWhenSellInLessThanZero(Item item);

    public class GildedRose
    {
        readonly IList<Item> _items;
        readonly Dictionary<string, QualityStrategyWhenSellInLessThanZero> _qualityStrategyWhenSellInLessThanZeroHandler;
        readonly ItemQualityUpdateStrategyFactory _itemQualityUpdateStrategyFactory = new ItemQualityUpdateStrategyFactory();


        public GildedRose(IList<Item> items)
        {
            
            _items = items;

            //convert to chain of responsiblity
            _qualityStrategyWhenSellInLessThanZeroHandler = new Dictionary<string, QualityStrategyWhenSellInLessThanZero>()
            {
                { "Aged Brie", UpdateBrieQualityWhenSellInLessThanZero },
                { "Backstage passes to a TAFKAL80ETC concert" , UpdateBackstageQualityWhenSellInLessThanZero }
            };
        }

        public void UpdateQuality()
        {
            foreach (Item item in _items.Where(item => item.Name != "Sulfuras, Hand of Ragnaros"))
            {
                //alreday converted to factory
                _itemQualityUpdateStrategyFactory.Create(item).UpdateQuality();

                UpdateSellIn(item);

                //TODO: convert to chain of responsibility
                UpdateItemQualityWhenSellInLessThanZero(item);
            }
        }

        public void UpdateSellIn(Item item)
        {
            item.SellIn--;
        }


        //convert all of below to chain of responsibility
        private void UpdateItemQualityWhenSellInLessThanZero(Item item)
        {
            if (_qualityStrategyWhenSellInLessThanZeroHandler.ContainsKey(item.Name))
            {
                _qualityStrategyWhenSellInLessThanZeroHandler[item.Name](item);
            }
            else
            {
                UpdateDefaultQualityWhenSellInLessThanZero(item);
            }
        }


        private static void UpdateDefaultQualityWhenSellInLessThanZero(Item item)
        {
            if ((item.SellIn < 0) && (item.Quality > 0))
            {
                item.Quality--;
            }

        }

        private static void UpdateBrieQualityWhenSellInLessThanZero(Item item)
        {
            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }
        }

        private static void UpdateBackstageQualityWhenSellInLessThanZero(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }

    }
}
