using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public interface IProductQualityUpdateStrategy
    {
        void UpdateQuality(Item item);
    }
}
