namespace cp_lab_13
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
            this.ProductGroubSelect = new System.Windows.Forms.ComboBox();
            this.HeaderGroup = new System.Windows.Forms.GroupBox();
            this.QuantityNumeric = new System.Windows.Forms.NumericUpDown();
            this.AddButton = new System.Windows.Forms.Button();
            this.CostAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ManufacturerName = new System.Windows.Forms.TextBox();
            this.ProductNameText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CurrencySelect = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.UnitsSelect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ProvidedSelect = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WarehouseView = new System.Windows.Forms.DataGridView();
            this.SummaryView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameFindTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.ItemFilterTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.FilterButton = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SortTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.sortToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.HeaderGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SummaryView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductGroubSelect
            // 
            this.ProductGroubSelect.FormattingEnabled = true;
            this.ProductGroubSelect.Location = new System.Drawing.Point(6, 57);
            this.ProductGroubSelect.Name = "ProductGroubSelect";
            this.ProductGroubSelect.Size = new System.Drawing.Size(92, 21);
            this.ProductGroubSelect.TabIndex = 0;
            // 
            // HeaderGroup
            // 
            this.HeaderGroup.Controls.Add(this.QuantityNumeric);
            this.HeaderGroup.Controls.Add(this.AddButton);
            this.HeaderGroup.Controls.Add(this.CostAmount);
            this.HeaderGroup.Controls.Add(this.label5);
            this.HeaderGroup.Controls.Add(this.ManufacturerName);
            this.HeaderGroup.Controls.Add(this.ProductNameText);
            this.HeaderGroup.Controls.Add(this.label8);
            this.HeaderGroup.Controls.Add(this.label7);
            this.HeaderGroup.Controls.Add(this.CurrencySelect);
            this.HeaderGroup.Controls.Add(this.label6);
            this.HeaderGroup.Controls.Add(this.UnitsSelect);
            this.HeaderGroup.Controls.Add(this.label4);
            this.HeaderGroup.Controls.Add(this.ProvidedSelect);
            this.HeaderGroup.Controls.Add(this.label3);
            this.HeaderGroup.Controls.Add(this.label2);
            this.HeaderGroup.Controls.Add(this.label1);
            this.HeaderGroup.Controls.Add(this.ProductGroubSelect);
            this.HeaderGroup.Location = new System.Drawing.Point(12, 27);
            this.HeaderGroup.Name = "HeaderGroup";
            this.HeaderGroup.Size = new System.Drawing.Size(1016, 100);
            this.HeaderGroup.TabIndex = 2;
            this.HeaderGroup.TabStop = false;
            this.HeaderGroup.Text = "Enter Data to place inside warehouse";
            // 
            // QuantityNumeric
            // 
            this.QuantityNumeric.Location = new System.Drawing.Point(680, 59);
            this.QuantityNumeric.Name = "QuantityNumeric";
            this.QuantityNumeric.Size = new System.Drawing.Size(80, 20);
            this.QuantityNumeric.TabIndex = 17;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(781, 57);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 16;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CostAmount
            // 
            this.CostAmount.Location = new System.Drawing.Point(503, 59);
            this.CostAmount.Name = "CostAmount";
            this.CostAmount.Size = new System.Drawing.Size(84, 20);
            this.CostAmount.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(500, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cost";
            // 
            // ManufacturerName
            // 
            this.ManufacturerName.Location = new System.Drawing.Point(210, 58);
            this.ManufacturerName.Name = "ManufacturerName";
            this.ManufacturerName.Size = new System.Drawing.Size(100, 20);
            this.ManufacturerName.TabIndex = 13;
            // 
            // ProductNameText
            // 
            this.ProductNameText.Location = new System.Drawing.Point(104, 58);
            this.ProductNameText.Name = "ProductNameText";
            this.ProductNameText.Size = new System.Drawing.Size(100, 20);
            this.ProductNameText.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(679, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(593, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Currency";
            // 
            // CurrencySelect
            // 
            this.CurrencySelect.FormattingEnabled = true;
            this.CurrencySelect.Location = new System.Drawing.Point(593, 59);
            this.CurrencySelect.Name = "CurrencySelect";
            this.CurrencySelect.Size = new System.Drawing.Size(80, 21);
            this.CurrencySelect.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(440, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Units";
            // 
            // UnitsSelect
            // 
            this.UnitsSelect.FormattingEnabled = true;
            this.UnitsSelect.Location = new System.Drawing.Point(443, 58);
            this.UnitsSelect.Name = "UnitsSelect";
            this.UnitsSelect.Size = new System.Drawing.Size(54, 21);
            this.UnitsSelect.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(316, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Provider";
            // 
            // ProvidedSelect
            // 
            this.ProvidedSelect.FormattingEnabled = true;
            this.ProvidedSelect.Location = new System.Drawing.Point(316, 57);
            this.ProvidedSelect.Name = "ProvidedSelect";
            this.ProvidedSelect.Size = new System.Drawing.Size(121, 21);
            this.ProvidedSelect.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Manufacturer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Group";
            // 
            // WarehouseView
            // 
            this.WarehouseView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WarehouseView.Location = new System.Drawing.Point(12, 133);
            this.WarehouseView.Name = "WarehouseView";
            this.WarehouseView.Size = new System.Drawing.Size(1016, 390);
            this.WarehouseView.TabIndex = 3;
            // 
            // SummaryView
            // 
            this.SummaryView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SummaryView.Location = new System.Drawing.Point(12, 529);
            this.SummaryView.Name = "SummaryView";
            this.SummaryView.Size = new System.Drawing.Size(1016, 86);
            this.SummaryView.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.findToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.sortToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1040, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NameFindTxtBox});
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.findToolStripMenuItem.Text = "Find";
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemFilterTxtBox,
            this.FilterButton});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveCSVBtn_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsCSVBtn_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadCSVBtn_Click);
            // 
            // NameFindTxtBox
            // 
            this.NameFindTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameFindTxtBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NameFindTxtBox.Name = "NameFindTxtBox";
            this.NameFindTxtBox.Size = new System.Drawing.Size(100, 23);
            this.NameFindTxtBox.TextChanged += new System.EventHandler(this.NameFindTxtBox_TextChanged);
            // 
            // ItemFilterTxtBox
            // 
            this.ItemFilterTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemFilterTxtBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ItemFilterTxtBox.Name = "ItemFilterTxtBox";
            this.ItemFilterTxtBox.Size = new System.Drawing.Size(100, 23);
            // 
            // FilterButton
            // 
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(180, 22);
            this.FilterButton.Text = "Filter";
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SortTxtBox,
            this.sortToolStripMenuItem1});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.sortToolStripMenuItem.Text = "Sort";
            // 
            // SortTxtBox
            // 
            this.SortTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SortTxtBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SortTxtBox.Name = "SortTxtBox";
            this.SortTxtBox.Size = new System.Drawing.Size(100, 23);
            // 
            // sortToolStripMenuItem1
            // 
            this.sortToolStripMenuItem1.Name = "sortToolStripMenuItem1";
            this.sortToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.sortToolStripMenuItem1.Text = "Sort";
            this.sortToolStripMenuItem1.Click += new System.EventHandler(this.sortToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 627);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.SummaryView);
            this.Controls.Add(this.WarehouseView);
            this.Controls.Add(this.HeaderGroup);
            this.Name = "Form1";
            this.Text = "Form1";
            this.HeaderGroup.ResumeLayout(false);
            this.HeaderGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SummaryView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ProductGroubSelect;
        private System.Windows.Forms.GroupBox HeaderGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ProvidedSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ManufacturerName;
        private System.Windows.Forms.TextBox ProductNameText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CurrencySelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox UnitsSelect;
        private System.Windows.Forms.TextBox CostAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.NumericUpDown QuantityNumeric;
        private System.Windows.Forms.DataGridView WarehouseView;
        private System.Windows.Forms.DataGridView SummaryView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox NameFindTxtBox;
        private System.Windows.Forms.ToolStripTextBox ItemFilterTxtBox;
        private System.Windows.Forms.ToolStripMenuItem FilterButton;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox SortTxtBox;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem1;
    }
}

