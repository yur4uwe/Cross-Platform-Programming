using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp_lab_9
{
    internal class Fridge
    {
        private Dictionary<string, int> items = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        public int this[string name]
        {
            get
            {
                if (items.ContainsKey(name))
                    return items[name];
                else
                    return 0;
            }
            set
            {
                if (value < 0) value = 0;

                if (items.ContainsKey(name))
                    items[name] = value;
                else
                    items.Add(name, value);
            }
        }

        public string GetContents()
        {
            if (items.Count == 0)
                return "(Fridge is empty)";

            string result = "Current fridge contents:" + Environment.NewLine;
            foreach (var kv in items)
                result += $"{kv.Key}: {kv.Value}" + Environment.NewLine;
            return result;
        }
    }
}
