namespace cp_lab_8_add1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.RaritySortButton = new System.Windows.Forms.Button();
            this.NameSortButton = new System.Windows.Forms.Button();
            this.ValueSortButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.cmbRarity = new System.Windows.Forms.ComboBox();
            this.nudValue = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.InventoryItems = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(202, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inventory";
            // 
            // RaritySortButton
            // 
            this.RaritySortButton.Location = new System.Drawing.Point(420, 26);
            this.RaritySortButton.Name = "RaritySortButton";
            this.RaritySortButton.Size = new System.Drawing.Size(125, 23);
            this.RaritySortButton.TabIndex = 2;
            this.RaritySortButton.Text = "Sort By Rarity UP";
            this.RaritySortButton.UseVisualStyleBackColor = true;
            this.RaritySortButton.Click += new System.EventHandler(this.RaritySortButton_Click);
            // 
            // NameSortButton
            // 
            this.NameSortButton.Location = new System.Drawing.Point(551, 26);
            this.NameSortButton.Name = "NameSortButton";
            this.NameSortButton.Size = new System.Drawing.Size(125, 23);
            this.NameSortButton.TabIndex = 3;
            this.NameSortButton.Text = "Sort By Name UP";
            this.NameSortButton.UseVisualStyleBackColor = true;
            this.NameSortButton.Click += new System.EventHandler(this.NameSortButton_Click);
            // 
            // ValueSortButton
            // 
            this.ValueSortButton.Location = new System.Drawing.Point(682, 26);
            this.ValueSortButton.Name = "ValueSortButton";
            this.ValueSortButton.Size = new System.Drawing.Size(125, 23);
            this.ValueSortButton.TabIndex = 4;
            this.ValueSortButton.Text = "Sort by Value UP";
            this.ValueSortButton.UseVisualStyleBackColor = true;
            this.ValueSortButton.Click += new System.EventHandler(this.ValueSortButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Add item";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(11, 70);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 6;
            // 
            // cmbRarity
            // 
            this.cmbRarity.FormattingEnabled = true;
            this.cmbRarity.Location = new System.Drawing.Point(10, 113);
            this.cmbRarity.Name = "cmbRarity";
            this.cmbRarity.Size = new System.Drawing.Size(121, 21);
            this.cmbRarity.TabIndex = 7;
            // 
            // nudValue
            // 
            this.nudValue.Location = new System.Drawing.Point(10, 157);
            this.nudValue.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.nudValue.Name = "nudValue";
            this.nudValue.Size = new System.Drawing.Size(120, 20);
            this.nudValue.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Enter a name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Select rarity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(8, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Enter value";
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Location = new System.Drawing.Point(10, 183);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(101, 23);
            this.buttonAddItem.TabIndex = 12;
            this.buttonAddItem.Text = "Add Item";
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // InventoryItems
            // 
            this.InventoryItems.AutoScroll = true;
            this.InventoryItems.Location = new System.Drawing.Point(207, 55);
            this.InventoryItems.Name = "InventoryItems";
            this.InventoryItems.Size = new System.Drawing.Size(617, 388);
            this.InventoryItems.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 450);
            this.Controls.Add(this.NameSortButton);
            this.Controls.Add(this.InventoryItems);
            this.Controls.Add(this.ValueSortButton);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudValue);
            this.Controls.Add(this.cmbRarity);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RaritySortButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RaritySortButton;
        private System.Windows.Forms.Button NameSortButton;
        private System.Windows.Forms.Button ValueSortButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.ComboBox cmbRarity;
        private System.Windows.Forms.NumericUpDown nudValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Panel InventoryItems;
    }
}

