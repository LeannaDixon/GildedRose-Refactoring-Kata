using System;
using System.Collections.Generic;
using System.Linq;

namespace csharpcore
{
    delegate void QualityStrategy(Item item);
    delegate void SellInStrategy(Item item);

    public class GildedRose
    {
        IList<Item> Items;

        Dictionary<string, QualityStrategy> QualityStrategyHandler;
        Dictionary<string, SellInStrategy> SellInStrategyHandler;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;

            QualityStrategyHandler = new Dictionary<string, QualityStrategy>()
            {
                {"Aged Brie", UpdateBrieQuality },
                {"Backstage passes to a TAFKAL80ETC concert" , UpdateBackstageQuality }
            };

            SellInStrategyHandler = new Dictionary<string, SellInStrategy>()
            {
                {"Aged Brie", UpdateBrieSellIn },
                {"Backstage passes to a TAFKAL80ETC concert" , UpdateBackstageSellIn }

            };
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items.Where(item => item.Name != "Sulfuras, Hand of Ragnaros"))
            {
                UpdateItemQuality(item);
                UpdateSellIn(item);
                UpdateItemSellIn(item);
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

       private static void UpdateItemSellIn(Item item) {
            if (item.SellIn < 0)
            {
                if (item.Name == "Aged Brie")
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }
                else if ((item.Name != "Backstage passes to a TAFKAL80ETC concert") && (item.Quality > 0))
                {
                    item.Quality--;
                }
                else
                {
                    item.Quality = 0;
                }
            }
       }
        private static void UpdateBrieSellIn(Item item)
        {
            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }
        }

        private static void UpdateBackstageSellIn(Item item)
        {
            if (item.SellIn > 0)
            {
                item.SellIn = 0;
            }
        }

        private static void UpdateDefaultSellIn(Item item)
        {

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

        private void UpdateItemSellInHandler(Item item)
        {
            if (SellInStrategyHandler.ContainsKey(item.Name))
            {
                SellInStrategyHandler[item.Name](item);
            }
            else
            {
                DefaultItemSellInStrategy(item);
            }
        }

        private static void DefaultItemQualityStrategy(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
        private static void DefaultItemSellInStrategy(Item item)
        {
            if (item.SellIn > 0)
            {
                item.SellIn--;
            }
        }
    }
}
