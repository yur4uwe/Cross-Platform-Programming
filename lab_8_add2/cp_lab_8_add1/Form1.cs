using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cp_lab_8_add1
{
    public partial class Form1 : Form
    {
        bool SortRarityInverse = false;
        bool SortValueInverse = false;
        bool SortNameInverse = false;
        bool SortRarity = false;
        bool SortValue = false;
        bool SortName = false;

        private Inventory inventory = new Inventory();

        public Form1()
        {
            InitializeComponent();

            cmbRarity.DataSource = Enum.GetValues(typeof(Rarity));
            UpdateList();
        }

        private void RaritySortButton_Click(object sender, EventArgs e)
        {
            if (SortRarity)
            {
                SortRarityInverse = !SortRarityInverse;

                Button b = (Button)sender;

                var list = b.Text.Split(' ');
                list[list.Length - 1] = SortRarityInverse ? "DOWN" : "UP";
                b.Text = string.Join(" ", list);
            }

            SortRarity = true;
            SortValue = false;
            SortName = false;

            inventory.Sort(new RarityComparer(), !SortRarityInverse);
            UpdateList();
        }

        private void NameSortButton_Click(object sender, EventArgs e)
        {
            if (SortName)
            {
                SortNameInverse = !SortNameInverse;

                Button b = (Button)sender;

                var list = b.Text.Split(' ');
                list[list.Length - 1] = SortNameInverse ? "DOWN" : "UP";
                b.Text = string.Join(" ", list);
            }

            SortName = true;
            SortValue = false;
            SortRarity = false;

            inventory.Sort(new NameComparer(), !SortNameInverse);
            UpdateList();
        }

        private void ValueSortButton_Click(object sender, EventArgs e)
        {
            if (SortValue)
            {
                SortValueInverse = !SortValueInverse;

                Button b = (Button)sender;

                var list = b.Text.Split(' ');
                list[list.Length - 1] = SortValueInverse ? "DOWN" : "UP";
                b.Text = string.Join(" ", list);
            }

            SortValue = true;
            SortRarity = false;
            SortName = false;

            inventory.Sort(null, !SortValueInverse);
            UpdateList();
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            var Item = new Item(
                NameTextBox.Text,
                (Rarity)cmbRarity.SelectedItem,
                (int)nudValue.Value
            );

            inventory.AddItem(Item);
            UpdateList();
        }

        private void UpdateList()
        {
            InventoryItems.Controls.Clear();
            var itemSize = new Size(80, 80);
            int itemsPerRow = 7, padding = 5;
            int r = 0, c = 0;

            foreach (var item in inventory)
            {
                if (r >= itemsPerRow)
                {
                    r = 0;
                    c++;
                }

                var ctrl = new ItemControl(item);

                ctrl.Location = new Point(
                    r * (itemSize.Width + padding),
                    c * (itemSize.Height + padding)
                );

                InventoryItems.Controls.Add(ctrl);

                r++;
            }
        }
    }
}
