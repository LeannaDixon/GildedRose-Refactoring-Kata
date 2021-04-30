﻿using System.Collections.Generic;
using System.Linq;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items.Where(item => item.Name != "Sulfuras, Hand of Ragnaros"))
            {

                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
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
                            if ((item.SellIn < 11 ) && (item.Quality < 50))
                            {
                                item.Quality = item.Quality + 1;
                            }

                            if ((item.SellIn < 6) && (item.Quality < 50))
                            {
                                item.Quality = item.Quality + 1;
                                
                            }
                        }
                    }
                }

                UpdateSellIn(item);

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if ((item.Name != "Backstage passes to a TAFKAL80ETC concert") && (item.Quality > 0))
                        {
                                
                            item.Quality = item.Quality - 1;
                                
                        }
                        
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
