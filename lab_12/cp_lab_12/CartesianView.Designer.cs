namespace cp_lab_12
{
    partial class CartesianView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SwitchToApproxButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ShiftNumeric = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.MultiplierNumeric = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.FuncComboBox = new System.Windows.Forms.ComboBox();
            this.HotReload = new System.Windows.Forms.CheckBox();
            this.SwitchToPolarButton = new System.Windows.Forms.Button();
            this.GraphButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PointCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.RangeEnd = new System.Windows.Forms.NumericUpDown();
            this.RangeStart = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiplierNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeStart)).BeginInit();
            this.SuspendLayout();
            // 
            // SwitchToApproxButton
            // 
            this.SwitchToApproxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SwitchToApproxButton.Location = new System.Drawing.Point(7, 365);
            this.SwitchToApproxButton.Name = "SwitchToApproxButton";
            this.SwitchToApproxButton.Size = new System.Drawing.Size(159, 32);
            this.SwitchToApproxButton.TabIndex = 35;
            this.SwitchToApproxButton.Text = "Open Approx";
            this.SwitchToApproxButton.UseVisualStyleBackColor = true;
            this.SwitchToApproxButton.Click += new System.EventHandler(this.SwitchToApproxButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(28, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 20);
            this.label7.TabIndex = 34;
            this.label7.Text = "shift";
            // 
            // ShiftNumeric
            // 
            this.ShiftNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShiftNumeric.Location = new System.Drawing.Point(75, 191);
            this.ShiftNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.ShiftNumeric.Name = "ShiftNumeric";
            this.ShiftNumeric.Size = new System.Drawing.Size(54, 26);
            this.ShiftNumeric.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(28, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "mult";
            // 
            // MultiplierNumeric
            // 
            this.MultiplierNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MultiplierNumeric.Location = new System.Drawing.Point(75, 159);
            this.MultiplierNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.MultiplierNumeric.Name = "MultiplierNumeric";
            this.MultiplierNumeric.Size = new System.Drawing.Size(54, 26);
            this.MultiplierNumeric.TabIndex = 31;
            this.MultiplierNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Choose the function";
            // 
            // FuncComboBox
            // 
            this.FuncComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FuncComboBox.FormattingEnabled = true;
            this.FuncComboBox.Location = new System.Drawing.Point(7, 128);
            this.FuncComboBox.Name = "FuncComboBox";
            this.FuncComboBox.Size = new System.Drawing.Size(121, 28);
            this.FuncComboBox.TabIndex = 29;
            // 
            // HotReload
            // 
            this.HotReload.AutoSize = true;
            this.HotReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HotReload.Location = new System.Drawing.Point(7, 297);
            this.HotReload.Name = "HotReload";
            this.HotReload.Size = new System.Drawing.Size(109, 24);
            this.HotReload.TabIndex = 28;
            this.HotReload.Text = "Hot Reload";
            this.HotReload.UseVisualStyleBackColor = true;
            this.HotReload.CheckedChanged += new System.EventHandler(this.HotReload_CheckedChanged);
            // 
            // SwitchToPolarButton
            // 
            this.SwitchToPolarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SwitchToPolarButton.Location = new System.Drawing.Point(7, 403);
            this.SwitchToPolarButton.Name = "SwitchToPolarButton";
            this.SwitchToPolarButton.Size = new System.Drawing.Size(159, 36);
            this.SwitchToPolarButton.TabIndex = 27;
            this.SwitchToPolarButton.Text = "Open Polar";
            this.SwitchToPolarButton.UseVisualStyleBackColor = true;
            this.SwitchToPolarButton.Click += new System.EventHandler(this.SwitchToPolarButton_Click);
            // 
            // GraphButton
            // 
            this.GraphButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GraphButton.Location = new System.Drawing.Point(7, 327);
            this.GraphButton.Name = "GraphButton";
            this.GraphButton.Size = new System.Drawing.Size(159, 32);
            this.GraphButton.TabIndex = 26;
            this.GraphButton.Text = "Graph";
            this.GraphButton.UseVisualStyleBackColor = true;
            this.GraphButton.Click += new System.EventHandler(this.GraphButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "N";
            // 
            // PointCount
            // 
            this.PointCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointCount.Location = new System.Drawing.Point(52, 67);
            this.PointCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PointCount.Name = "PointCount";
            this.PointCount.Size = new System.Drawing.Size(61, 26);
            this.PointCount.TabIndex = 24;
            this.PointCount.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "End";
            // 
            // RangeEnd
            // 
            this.RangeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RangeEnd.Location = new System.Drawing.Point(52, 35);
            this.RangeEnd.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.RangeEnd.Name = "RangeEnd";
            this.RangeEnd.Size = new System.Drawing.Size(60, 26);
            this.RangeEnd.TabIndex = 22;
            this.RangeEnd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // RangeStart
            // 
            this.RangeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RangeStart.Location = new System.Drawing.Point(52, 0);
            this.RangeStart.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.RangeStart.Name = "RangeStart";
            this.RangeStart.Size = new System.Drawing.Size(61, 26);
            this.RangeStart.TabIndex = 21;
            this.RangeStart.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Start";
            // 
            // CartesianView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SwitchToApproxButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ShiftNumeric);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MultiplierNumeric);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FuncComboBox);
            this.Controls.Add(this.HotReload);
            this.Controls.Add(this.SwitchToPolarButton);
            this.Controls.Add(this.GraphButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PointCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RangeEnd);
            this.Controls.Add(this.RangeStart);
            this.Controls.Add(this.label1);
            this.Name = "CartesianView";
            this.Size = new System.Drawing.Size(195, 450);
            ((System.ComponentModel.ISupportInitialize)(this.ShiftNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiplierNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SwitchToApproxButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown ShiftNumeric;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown MultiplierNumeric;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox FuncComboBox;
        private System.Windows.Forms.CheckBox HotReload;
        private System.Windows.Forms.Button SwitchToPolarButton;
        private System.Windows.Forms.Button GraphButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown PointCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown RangeEnd;
        private System.Windows.Forms.NumericUpDown RangeStart;
        private System.Windows.Forms.Label label1;
    }
}
