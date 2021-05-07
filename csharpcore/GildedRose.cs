using System;
using System.Collections.Generic;
using System.Linq;

namespace csharpcore
{
    delegate void QualityStrategy(Item item);

    public class GildedRose
    {
        IList<Item> Items;

        Dictionary<string, QualityStrategy> QualityStrategyHandler;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;

            QualityStrategyHandler = new Dictionary<string, QualityStrategy>()
            {
                {"Aged Brie", UpdateBrieQuality },
                {"Backstage passes to a TAFKAL80ETC concert" , UpdateBackstageQuality }
            };
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

        public void UpdateQuality()
        {
            foreach (Item item in Items.Where(item => item.Name != "Sulfuras, Hand of Ragnaros"))
            {
                UpdateItemQuality(item);

                UpdateSellIn(item);

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
        }

        private void UpdateItemQuality(Item item)
        {
            if (QualityStrategyHandler.ContainsKey(item.Name))
            {
                QualityStrategyHandler[item.Name](item);
            }
            else
            {
                DefaultItemStrategy(item);
            }
        }

        private static void DefaultItemStrategy(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}
