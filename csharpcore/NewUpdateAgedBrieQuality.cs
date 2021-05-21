using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public class NewUpdateAgedBrieQuality : NewUpdateQuality
    {
        public NewUpdateAgedBrieQuality(Item item) : base(item)
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
