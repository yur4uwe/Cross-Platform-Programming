using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cp_lab_9
{
    public partial class Form1 : Form
    {
        private Fridge fridge = new Fridge();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string item = txtItem.Text.Trim();
            if (string.IsNullOrEmpty(item))
            {
                txtOutput.Text = "Please enter an item name.";
                return;
            }

            int quantity = (int)updownQty.Value;

            fridge[item] = quantity;
            txtOutput.Text = $"Set '{item}' quantity to {quantity}.";
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            string item = txtItem.Text.Trim();
            if (string.IsNullOrEmpty(item))
            {
                txtOutput.Text = "Please enter an item name.";
                return;
            }

            int qty = fridge[item];
            txtOutput.Text = qty > 0
                ? $"There are {qty} {item}(s) in the fridge."
                : $"No {item} found in the fridge.";
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtOutput.Text = fridge.GetContents();
        }
    }
}
