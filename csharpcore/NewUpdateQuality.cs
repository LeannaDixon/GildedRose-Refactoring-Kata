using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public class NewUpdateQuality 
    {
        protected Item Item { get; }

        public NewUpdateQuality(Item item)
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
