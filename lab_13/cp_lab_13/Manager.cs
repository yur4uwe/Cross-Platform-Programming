using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp_lab_13
{
    public class WarehouseManager
    {
        private readonly List<TWarehouse> _warehouses = new List<TWarehouse>();

        public IReadOnlyList<TWarehouse> Warehouses => _warehouses;

        public event Action WarehousesChanged;

        public void AddWarehouse(string name, TWarehouse warehouse)
        {
            if (warehouse == null) throw new ArgumentNullException(nameof(warehouse));
            warehouse.WarehouseTable.ExtendedProperties["Name"] = name;
            _warehouses.Add(warehouse);
            WarehousesChanged?.Invoke();
        }

        public bool RemoveWarehouse(string name)
        {
            var w = _warehouses.FirstOrDefault(x =>
                string.Equals(x.WarehouseTable.ExtendedProperties["Name"] as string, name, StringComparison.Ordinal));
            if (w == null) return false;
            _warehouses.Remove(w);
            WarehousesChanged?.Invoke();
            return true;
        }

        public TWarehouse this[string name]
        {
            get
            {
                if (name == null) throw new ArgumentNullException(nameof(name));
                return _warehouses.FirstOrDefault(x =>
                    string.Equals(
                        x.WarehouseTable.ExtendedProperties["Name"] as string,
                        name,
                        StringComparison.Ordinal
                    )
                );
            }
            set
            {
                if (name == null) throw new ArgumentNullException(nameof(name));
                if (value == null) throw new ArgumentNullException(nameof(value));

                int idx = _warehouses.FindIndex(x =>
                    string.Equals(x.WarehouseTable.ExtendedProperties["Name"] as string, name, StringComparison.Ordinal));

                value.WarehouseTable.ExtendedProperties["Name"] = name;

                if (idx >= 0)
                {
                    _warehouses[idx] = value;
                }
                else
                {
                    _warehouses.Add(value);
                }

                WarehousesChanged?.Invoke();
            }
        }

        public TWarehouse this[int index]
        {
            get
            {
                if (index < 0 || index >= _warehouses.Count) throw new ArgumentOutOfRangeException(nameof(index));
                return _warehouses[index];
            }
            set
            {
                if (index < 0 || index >= _warehouses.Count) throw new ArgumentOutOfRangeException(nameof(index));
                if (value == null) throw new ArgumentNullException(nameof(value));

                var existingName = _warehouses[index].WarehouseTable.ExtendedProperties["Name"] as string;
                var newName = value.WarehouseTable.ExtendedProperties["Name"] as string;
                if (string.IsNullOrEmpty(newName) && !string.IsNullOrEmpty(existingName))
                {
                    value.WarehouseTable.ExtendedProperties["Name"] = existingName;
                }

                _warehouses[index] = value;
                WarehousesChanged?.Invoke();
            }
        }
    }
}
