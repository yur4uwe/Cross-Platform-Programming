namespace cp_lab_12
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RangeStart = new System.Windows.Forms.NumericUpDown();
            this.RangeEnd = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.PointCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.GraphButton = new System.Windows.Forms.Button();
            this.SwitchToPolarButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ApproxDegree = new System.Windows.Forms.NumericUpDown();
            this.FuncComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MultiplierNumeric = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.ShiftNumeric = new System.Windows.Forms.NumericUpDown();
            this.LoadCsvButton = new System.Windows.Forms.Button();
            this.ToApproximateCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApproxDegree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiplierNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(693, 488);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(699, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start";
            // 
            // RangeStart
            // 
            this.RangeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RangeStart.Location = new System.Drawing.Point(748, 7);
            this.RangeStart.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.RangeStart.Name = "RangeStart";
            this.RangeStart.Size = new System.Drawing.Size(61, 26);
            this.RangeStart.TabIndex = 3;
            this.RangeStart.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            // 
            // RangeEnd
            // 
            this.RangeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RangeEnd.Location = new System.Drawing.Point(748, 42);
            this.RangeEnd.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.RangeEnd.Name = "RangeEnd";
            this.RangeEnd.Size = new System.Drawing.Size(60, 26);
            this.RangeEnd.TabIndex = 4;
            this.RangeEnd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(705, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "End";
            // 
            // PointCount
            // 
            this.PointCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointCount.Location = new System.Drawing.Point(748, 74);
            this.PointCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PointCount.Name = "PointCount";
            this.PointCount.Size = new System.Drawing.Size(61, 26);
            this.PointCount.TabIndex = 6;
            this.PointCount.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(705, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "N";
            // 
            // GraphButton
            // 
            this.GraphButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GraphButton.Location = new System.Drawing.Point(703, 363);
            this.GraphButton.Name = "GraphButton";
            this.GraphButton.Size = new System.Drawing.Size(156, 32);
            this.GraphButton.TabIndex = 8;
            this.GraphButton.Text = "Graph";
            this.GraphButton.UseVisualStyleBackColor = true;
            this.GraphButton.Click += new System.EventHandler(this.GraphButton_Click);
            // 
            // SwitchToPolarButton
            // 
            this.SwitchToPolarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SwitchToPolarButton.Location = new System.Drawing.Point(703, 439);
            this.SwitchToPolarButton.Name = "SwitchToPolarButton";
            this.SwitchToPolarButton.Size = new System.Drawing.Size(159, 36);
            this.SwitchToPolarButton.TabIndex = 9;
            this.SwitchToPolarButton.Text = "Open Polar";
            this.SwitchToPolarButton.UseVisualStyleBackColor = true;
            this.SwitchToPolarButton.Click += new System.EventHandler(this.SwitchToPolarButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.Location = new System.Drawing.Point(703, 333);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 24);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Hot Reload";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(699, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Approximation degree";
            // 
            // ApproxDegree
            // 
            this.ApproxDegree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApproxDegree.Location = new System.Drawing.Point(703, 161);
            this.ApproxDegree.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ApproxDegree.Name = "ApproxDegree";
            this.ApproxDegree.Size = new System.Drawing.Size(120, 26);
            this.ApproxDegree.TabIndex = 11;
            this.ApproxDegree.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // FuncComboBox
            // 
            this.FuncComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FuncComboBox.FormattingEnabled = true;
            this.FuncComboBox.Location = new System.Drawing.Point(703, 213);
            this.FuncComboBox.Name = "FuncComboBox";
            this.FuncComboBox.Size = new System.Drawing.Size(121, 28);
            this.FuncComboBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(699, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Choose the function";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(724, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "mult";
            // 
            // MultiplierNumeric
            // 
            this.MultiplierNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MultiplierNumeric.Location = new System.Drawing.Point(771, 244);
            this.MultiplierNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MultiplierNumeric.Name = "MultiplierNumeric";
            this.MultiplierNumeric.Size = new System.Drawing.Size(54, 26);
            this.MultiplierNumeric.TabIndex = 15;
            this.MultiplierNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(724, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "shift";
            // 
            // ShiftNumeric
            // 
            this.ShiftNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShiftNumeric.Location = new System.Drawing.Point(771, 276);
            this.ShiftNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ShiftNumeric.Name = "ShiftNumeric";
            this.ShiftNumeric.Size = new System.Drawing.Size(54, 26);
            this.ShiftNumeric.TabIndex = 17;
            // 
            // LoadCsvButton
            // 
            this.LoadCsvButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadCsvButton.Location = new System.Drawing.Point(703, 401);
            this.LoadCsvButton.Name = "LoadCsvButton";
            this.LoadCsvButton.Size = new System.Drawing.Size(159, 32);
            this.LoadCsvButton.TabIndex = 19;
            this.LoadCsvButton.Text = "Load csv";
            this.LoadCsvButton.UseVisualStyleBackColor = true;
            this.LoadCsvButton.Click += new System.EventHandler(this.LoadCsvButton_Click);
            // 
            // ToApproximateCheckBox
            // 
            this.ToApproximateCheckBox.AutoSize = true;
            this.ToApproximateCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToApproximateCheckBox.Location = new System.Drawing.Point(703, 111);
            this.ToApproximateCheckBox.Name = "ToApproximateCheckBox";
            this.ToApproximateCheckBox.Size = new System.Drawing.Size(117, 24);
            this.ToApproximateCheckBox.TabIndex = 20;
            this.ToApproximateCheckBox.Text = "Approximate";
            this.ToApproximateCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 485);
            this.Controls.Add(this.ToApproximateCheckBox);
            this.Controls.Add(this.LoadCsvButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ShiftNumeric);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MultiplierNumeric);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FuncComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ApproxDegree);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.SwitchToPolarButton);
            this.Controls.Add(this.GraphButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PointCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RangeEnd);
            this.Controls.Add(this.RangeStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApproxDegree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiplierNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown RangeStart;
        private System.Windows.Forms.NumericUpDown RangeEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown PointCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button GraphButton;
        private System.Windows.Forms.Button SwitchToPolarButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ApproxDegree;
        private System.Windows.Forms.ComboBox FuncComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown MultiplierNumeric;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown ShiftNumeric;
        private System.Windows.Forms.Button LoadCsvButton;
        private System.Windows.Forms.CheckBox ToApproximateCheckBox;
    }
}

