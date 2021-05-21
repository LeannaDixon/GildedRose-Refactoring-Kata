using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public class ItemQualityUpdateStrategyFactory
    {

        public DefaultQualityUpdateStrategy Create(Item Item)
        {
            switch (Item.Name)
            {
                case "Aged Brie":
                    return new AgedBrieQualityUpdateStrategy(Item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassQualityUpdateStrategy(Item);
                default:
                    return new DefaultQualityUpdateStrategy(Item);
            }
        }
    }
}
