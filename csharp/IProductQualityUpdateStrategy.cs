using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    interface IProductQualityUpdateStrategy
    {
        void UpdateQuality(Item item);
    }

    public class SulfurasQualityUpdateStrategy : IProductQualityUpdateStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.Quality = 80;
        }
    }
}
