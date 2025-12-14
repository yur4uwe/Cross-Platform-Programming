using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp_lab_8_add1
{
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }

    public class Item : IComparable<Item>
    {
        public string Name { get; set; }
        public Rarity Rarity { get; set; }
        public int Value { get; set; }

        public Item(string name, Rarity rarity, int value)
        {
            Name = name;
            Rarity = rarity;
            Value = value;
        }

        public int CompareTo(Item other)
        {
            if (other == null) return 1;
            return other.Value.CompareTo(Value); // descending by value
        }

        public override string ToString()
        {
            return $"{Name} ({Rarity}, {Value} gold)";
        }
    }
}
