using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public class DefaultQualityUpdateStrategy 
    {
        protected Item Item { get; }

        public DefaultQualityUpdateStrategy(Item item)
        {
            Item = item;
        }
        public virtual void UpdateQuality()
        {
            if (Item.Quality > 0)
            {
                Item.Quality--;
            }

        }
    }
}
