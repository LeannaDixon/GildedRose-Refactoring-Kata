using System;
using System.Collections.Generic;
using System.Linq;

namespace csharpcore
{
    delegate void QualityStrategy(Item item);
    delegate void QualityStrategyWhenSellInLessThanZero(Item item);

    public class GildedRose
    {
        IList<Item> Items;

        Dictionary<string, QualityStrategy> QualityStrategyHandler;
        Dictionary<string, QualityStrategyWhenSellInLessThanZero> QualityStrategyWhenSellInLessThanZeroHandler;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;

            QualityStrategyHandler = new Dictionary<string, QualityStrategy>()
            {
                {"Aged Brie", UpdateBrieQuality },
                {"Backstage passes to a TAFKAL80ETC concert" , UpdateBackstageQuality }
            };

            QualityStrategyWhenSellInLessThanZeroHandler = new Dictionary<string, QualityStrategyWhenSellInLessThanZero>()
            {
                {"Aged Brie", UpdateBrieQualityWhenSellInLessThanZero },
                {"Backstage passes to a TAFKAL80ETC concert" , UpdateBackstageQualityWhenSellInLessThanZero }

            };
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items.Where(item => item.Name != "Sulfuras, Hand of Ragnaros"))
            {
                UpdateItemQuality(item);
                UpdateSellIn(item);
                UpdateItemQualityWhenSellInLessThanZero(item);
            }
        }

        private void UpdateBackstageQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;

                if ((item.SellIn < 11) && (item.Quality < 50))
                {
                    item.Quality++;
                }

                if ((item.SellIn < 6) && (item.Quality < 50))
                {
                    item.Quality++;
                }
            }
        }

        private void UpdateBrieQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        public void UpdateSellIn(Item item)
        {
            item.SellIn--;
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

        private static void UpdateDefaultQualityWhenSellInLessThanZero(Item item)
        {   
            if((item.SellIn < 0)  && (item.Quality > 0))
            {
                item.Quality--;
            }

        }

        private void UpdateItemQuality(Item item)
        {
            if (QualityStrategyHandler.ContainsKey(item.Name))
            {
                QualityStrategyHandler[item.Name](item);
            }
            else
            {
                DefaultItemQualityStrategy(item);
            }
        }

        private void UpdateItemQualityWhenSellInLessThanZero(Item item)
        {
            if (QualityStrategyWhenSellInLessThanZeroHandler.ContainsKey(item.Name))
            {
                QualityStrategyWhenSellInLessThanZeroHandler[item.Name](item);
            }
            else
            {
                UpdateDefaultQualityWhenSellInLessThanZero(item);
            }
        }

        private static void DefaultItemQualityStrategy(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }

    }
}
