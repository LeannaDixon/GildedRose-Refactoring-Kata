using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public class BackstagePassQualityUpdateStrategy : DefaultQualityUpdateStrategy
    {
        public BackstagePassQualityUpdateStrategy(Item item) : base(item)
        {

        }
        public override void UpdateQuality()
        {
            if (Item.Quality < 50)
            {
                Item.Quality++;

                if ((Item.SellIn < 11) && (Item.Quality < 50))
                {
                    Item.Quality++;
                }

                if ((Item.SellIn < 6) && (Item.Quality < 50))
                {
                    Item.Quality++;
                }
            }
        }
    }
}
