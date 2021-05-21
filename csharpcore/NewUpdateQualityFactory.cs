using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public class NewUpdateQualityFactory
    {

        public NewUpdateQuality CreateUpdateQuality(Item Item)
        {
            switch (Item.Name)
            {
                case "Aged Brie":
                    return new NewUpdateAgedBrieQuality(Item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new NewUpdateBackstagePassesQuality(Item);
                default:
                    return new NewUpdateQuality(Item);
            }
        }
    }
}
