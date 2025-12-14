using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp_lab_8_add1
{
    public class Inventory : IEnumerable<Item>
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item) => items.Add(item);

        // Added `descending` flag and handle reversed comparer when one is provided.
        public void Sort(IComparer<Item> comparer = null, bool descending = false)
        {
            if (comparer == null)
            {
                items.Sort(); // uses IComparable<Item>
                if (descending)
                    items.Reverse();
            }
            else
            {
                if (descending)
                {
                    // Wrap provided comparer to invert comparison order
                    var reversed = Comparer<Item>.Create((x, y) => comparer.Compare(y, x));
                    items.Sort(reversed);
                }
                else
                {
                    items.Sort(comparer);
                }
            }
        }

        public IEnumerator<Item> GetEnumerator()
        {
            foreach (var item in items)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
