using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public class AgedBrieQualityUpdateStrategy : DefaultQualityUpdateStrategy
    {
        public AgedBrieQualityUpdateStrategy(Item item) : base(item)
        {

        }
        public override void UpdateQuality() 
        {
            if (Item.Quality < 50)
            {
                Item.Quality++;
            }
        }
    }
}
