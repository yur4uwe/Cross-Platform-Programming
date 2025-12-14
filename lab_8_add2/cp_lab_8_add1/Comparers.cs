using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp_lab_8_add1
{
    public class NameComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return string.Compare(x?.Name, y?.Name);
        }
    }

    public class RarityComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return x.Rarity.CompareTo(y.Rarity);
        }
    }
}
