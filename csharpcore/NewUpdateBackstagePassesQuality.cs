using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public class NewUpdateBackstagePassesQuality : NewUpdateQuality
    {
        public NewUpdateBackstagePassesQuality(Item item) : base(item)
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
