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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Warehouses");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.WarehouseTreeView = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveAsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.NameFindTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ItemFilterTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.filterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.SortTxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.sortToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintBtn = new System.Windows.Forms.ToolStripButton();
            this.StatsBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.totalValuePerGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowInStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalValuePerProviderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averagePricePerGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitsDistributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearButton = new System.Windows.Forms.Button();
            this.HeaderGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SummaryView)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            this.HeaderGroup.Controls.Add(this.ClearButton);
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
            this.HeaderGroup.Location = new System.Drawing.Point(12, 35);
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
            this.WarehouseView.Location = new System.Drawing.Point(139, 133);
            this.WarehouseView.Name = "WarehouseView";
            this.WarehouseView.Size = new System.Drawing.Size(889, 390);
            this.WarehouseView.TabIndex = 3;
            this.WarehouseView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.WarehouseView_DataError);
            // 
            // SummaryView
            // 
            this.SummaryView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SummaryView.Location = new System.Drawing.Point(12, 529);
            this.SummaryView.Name = "SummaryView";
            this.SummaryView.Size = new System.Drawing.Size(1016, 179);
            this.SummaryView.TabIndex = 4;
            // 
            // WarehouseTreeView
            // 
            this.WarehouseTreeView.Location = new System.Drawing.Point(12, 133);
            this.WarehouseTreeView.Name = "WarehouseTreeView";
            treeNode1.Name = "Warehouses";
            treeNode1.Text = "Warehouses";
            this.WarehouseTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.WarehouseTreeView.Size = new System.Drawing.Size(121, 390);
            this.WarehouseTreeView.TabIndex = 22;
            this.WarehouseTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.WarehousesTree_AfterSelect);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton4,
            this.PrintBtn,
            this.StatsBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1040, 32);
            this.toolStrip1.TabIndex = 23;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.loadToolStripMenuItem1});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 29);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // saveAsToolStripMenuItem1
            // 
            this.saveAsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem1.Image")));
            this.saveAsToolStripMenuItem1.Name = "saveAsToolStripMenuItem1";
            this.saveAsToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem1.Text = "Save As";
            this.saveAsToolStripMenuItem1.Click += new System.EventHandler(this.SaveAsCSVBtn_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem1.Image")));
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.SaveCSVBtn_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("loadToolStripMenuItem1.Image")));
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.loadToolStripMenuItem1.Text = "Load";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.LoadCSVBtn_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NameFindTxtBox});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(38, 29);
            this.toolStripDropDownButton2.Text = "toolStripDropDownButton2";
            // 
            // NameFindTxtBox
            // 
            this.NameFindTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameFindTxtBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NameFindTxtBox.Name = "NameFindTxtBox";
            this.NameFindTxtBox.Size = new System.Drawing.Size(100, 23);
            this.NameFindTxtBox.TextChanged += new System.EventHandler(this.NameFindTxtBox_TextChanged);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemFilterTxtBox,
            this.filterToolStripMenuItem1,
            this.clearToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(38, 29);
            this.toolStripDropDownButton3.Text = "toolStripDropDownButton3";
            // 
            // ItemFilterTxtBox
            // 
            this.ItemFilterTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemFilterTxtBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ItemFilterTxtBox.Name = "ItemFilterTxtBox";
            this.ItemFilterTxtBox.Size = new System.Drawing.Size(100, 23);
            // 
            // filterToolStripMenuItem1
            // 
            this.filterToolStripMenuItem1.Name = "filterToolStripMenuItem1";
            this.filterToolStripMenuItem1.Size = new System.Drawing.Size(189, 32);
            this.filterToolStripMenuItem1.Text = "Filter";
            this.filterToolStripMenuItem1.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clearToolStripMenuItem.Image")));
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(189, 32);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SortTxtBox,
            this.sortToolStripMenuItem2});
            this.toolStripDropDownButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton4.Image")));
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(38, 29);
            this.toolStripDropDownButton4.Text = "toolStripDropDownButton4";
            // 
            // SortTxtBox
            // 
            this.SortTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SortTxtBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SortTxtBox.Name = "SortTxtBox";
            this.SortTxtBox.Size = new System.Drawing.Size(100, 23);
            // 
            // sortToolStripMenuItem2
            // 
            this.sortToolStripMenuItem2.Name = "sortToolStripMenuItem2";
            this.sortToolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
            this.sortToolStripMenuItem2.Text = "Sort";
            this.sortToolStripMenuItem2.Click += new System.EventHandler(this.sortToolStripMenuItem1_Click);
            // 
            // PrintBtn
            // 
            this.PrintBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PrintBtn.Image = ((System.Drawing.Image)(resources.GetObject("PrintBtn.Image")));
            this.PrintBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(29, 29);
            this.PrintBtn.Text = "toolStripButton1";
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // StatsBtn
            // 
            this.StatsBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalValuePerGroupToolStripMenuItem,
            this.lowInStockToolStripMenuItem,
            this.totalValuePerProviderToolStripMenuItem,
            this.averagePricePerGroupToolStripMenuItem,
            this.unitsDistributionToolStripMenuItem});
            this.StatsBtn.Image = ((System.Drawing.Image)(resources.GetObject("StatsBtn.Image")));
            this.StatsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StatsBtn.Name = "StatsBtn";
            this.StatsBtn.Size = new System.Drawing.Size(91, 29);
            this.StatsBtn.Text = "Statistics";
            // 
            // totalValuePerGroupToolStripMenuItem
            // 
            this.totalValuePerGroupToolStripMenuItem.Name = "totalValuePerGroupToolStripMenuItem";
            this.totalValuePerGroupToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.totalValuePerGroupToolStripMenuItem.Text = "Total Value Per Group";
            this.totalValuePerGroupToolStripMenuItem.Click += new System.EventHandler(this.totalValuePerGroupToolStripMenuItem_Click);
            // 
            // lowInStockToolStripMenuItem
            // 
            this.lowInStockToolStripMenuItem.Name = "lowInStockToolStripMenuItem";
            this.lowInStockToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.lowInStockToolStripMenuItem.Text = "Low in Stock";
            this.lowInStockToolStripMenuItem.Click += new System.EventHandler(this.lowInStockToolStripMenuItem_Click);
            // 
            // totalValuePerProviderToolStripMenuItem
            // 
            this.totalValuePerProviderToolStripMenuItem.Name = "totalValuePerProviderToolStripMenuItem";
            this.totalValuePerProviderToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.totalValuePerProviderToolStripMenuItem.Text = "Total value per provider";
            this.totalValuePerProviderToolStripMenuItem.Click += new System.EventHandler(this.totalValuePerProviderToolStripMenuItem_Click);
            // 
            // averagePricePerGroupToolStripMenuItem
            // 
            this.averagePricePerGroupToolStripMenuItem.Name = "averagePricePerGroupToolStripMenuItem";
            this.averagePricePerGroupToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.averagePricePerGroupToolStripMenuItem.Text = "Average Price per Group";
            this.averagePricePerGroupToolStripMenuItem.Click += new System.EventHandler(this.averagePricePerGroupToolStripMenuItem_Click);
            // 
            // unitsDistributionToolStripMenuItem
            // 
            this.unitsDistributionToolStripMenuItem.Name = "unitsDistributionToolStripMenuItem";
            this.unitsDistributionToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.unitsDistributionToolStripMenuItem.Text = "Units Distribution";
            this.unitsDistributionToolStripMenuItem.Click += new System.EventHandler(this.unitsDistributionToolStripMenuItem_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(862, 57);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 18;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 720);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.WarehouseTreeView);
            this.Controls.Add(this.SummaryView);
            this.Controls.Add(this.WarehouseView);
            this.Controls.Add(this.HeaderGroup);
            this.Name = "Form1";
            this.Text = "Warehouse";
            this.HeaderGroup.ResumeLayout(false);
            this.HeaderGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SummaryView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.TreeView WarehouseTreeView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripTextBox NameFindTxtBox;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripTextBox ItemFilterTxtBox;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripTextBox SortTxtBox;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton PrintBtn;
        private System.Windows.Forms.ToolStripDropDownButton StatsBtn;
        private System.Windows.Forms.ToolStripMenuItem totalValuePerGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lowInStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalValuePerProviderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averagePricePerGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitsDistributionToolStripMenuItem;
        private System.Windows.Forms.Button ClearButton;
    }
}

