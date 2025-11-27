namespace cp_lab_12
{
    partial class PolarView
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
            this.SwitchToApprox = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ParamBNumeric = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ParamANumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.FuncComboBox = new System.Windows.Forms.ComboBox();
            this.Points = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.HotReload = new System.Windows.Forms.CheckBox();
            this.SwitchtoCartesianButton = new System.Windows.Forms.Button();
            this.GraphButton = new System.Windows.Forms.Button();
            this.PeriodNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ParamBNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParamANumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Points)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PeriodNum)).BeginInit();
            this.SuspendLayout();
            // 
            // SwitchToApprox
            // 
            this.SwitchToApprox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SwitchToApprox.Location = new System.Drawing.Point(7, 367);
            this.SwitchToApprox.Name = "SwitchToApprox";
            this.SwitchToApprox.Size = new System.Drawing.Size(147, 32);
            this.SwitchToApprox.TabIndex = 37;
            this.SwitchToApprox.Text = "Open Approx";
            this.SwitchToApprox.UseVisualStyleBackColor = true;
            this.SwitchToApprox.Click += new System.EventHandler(this.SwitchToApprox_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(27, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "b";
            // 
            // ParamBNumeric
            // 
            this.ParamBNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParamBNumeric.Location = new System.Drawing.Point(53, 184);
            this.ParamBNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ParamBNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.ParamBNumeric.Name = "ParamBNumeric";
            this.ParamBNumeric.Size = new System.Drawing.Size(54, 26);
            this.ParamBNumeric.TabIndex = 35;
            this.ParamBNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(29, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "a";
            // 
            // ParamANumeric
            // 
            this.ParamANumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParamANumeric.Location = new System.Drawing.Point(53, 152);
            this.ParamANumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ParamANumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.ParamANumeric.Name = "ParamANumeric";
            this.ParamANumeric.Size = new System.Drawing.Size(54, 26);
            this.ParamANumeric.TabIndex = 33;
            this.ParamANumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "Choose the function";
            // 
            // FuncComboBox
            // 
            this.FuncComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FuncComboBox.FormattingEnabled = true;
            this.FuncComboBox.Location = new System.Drawing.Point(7, 118);
            this.FuncComboBox.Name = "FuncComboBox";
            this.FuncComboBox.Size = new System.Drawing.Size(121, 28);
            this.FuncComboBox.TabIndex = 31;
            // 
            // Points
            // 
            this.Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Points.Location = new System.Drawing.Point(29, 55);
            this.Points.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Points.Name = "Points";
            this.Points.Size = new System.Drawing.Size(56, 26);
            this.Points.TabIndex = 30;
            this.Points.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "N";
            // 
            // HotReload
            // 
            this.HotReload.AutoSize = true;
            this.HotReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HotReload.Location = new System.Drawing.Point(7, 299);
            this.HotReload.Name = "HotReload";
            this.HotReload.Size = new System.Drawing.Size(109, 24);
            this.HotReload.TabIndex = 28;
            this.HotReload.Text = "Hot Reload";
            this.HotReload.UseVisualStyleBackColor = true;
            this.HotReload.CheckedChanged += new System.EventHandler(this.HotReload_CheckedChanged);
            // 
            // SwitchtoCartesianButton
            // 
            this.SwitchtoCartesianButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SwitchtoCartesianButton.Location = new System.Drawing.Point(7, 405);
            this.SwitchtoCartesianButton.Name = "SwitchtoCartesianButton";
            this.SwitchtoCartesianButton.Size = new System.Drawing.Size(147, 36);
            this.SwitchtoCartesianButton.TabIndex = 27;
            this.SwitchtoCartesianButton.Text = "Open Cartesian";
            this.SwitchtoCartesianButton.UseVisualStyleBackColor = true;
            this.SwitchtoCartesianButton.Click += new System.EventHandler(this.SwitchtoCartesianButton_Click);
            // 
            // GraphButton
            // 
            this.GraphButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GraphButton.Location = new System.Drawing.Point(7, 329);
            this.GraphButton.Name = "GraphButton";
            this.GraphButton.Size = new System.Drawing.Size(147, 32);
            this.GraphButton.TabIndex = 26;
            this.GraphButton.Text = "Graph";
            this.GraphButton.UseVisualStyleBackColor = true;
            this.GraphButton.Click += new System.EventHandler(this.GraphButton_Click);
            // 
            // PeriodNum
            // 
            this.PeriodNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PeriodNum.Location = new System.Drawing.Point(7, 23);
            this.PeriodNum.Name = "PeriodNum";
            this.PeriodNum.Size = new System.Drawing.Size(120, 26);
            this.PeriodNum.TabIndex = 25;
            this.PeriodNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "No of Periods";
            // 
            // PolarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SwitchToApprox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ParamBNumeric);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ParamANumeric);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FuncComboBox);
            this.Controls.Add(this.Points);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HotReload);
            this.Controls.Add(this.SwitchtoCartesianButton);
            this.Controls.Add(this.GraphButton);
            this.Controls.Add(this.PeriodNum);
            this.Controls.Add(this.label1);
            this.Name = "PolarView";
            this.Size = new System.Drawing.Size(195, 450);
            ((System.ComponentModel.ISupportInitialize)(this.ParamBNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParamANumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Points)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PeriodNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SwitchToApprox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown ParamBNumeric;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ParamANumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox FuncComboBox;
        private System.Windows.Forms.NumericUpDown Points;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox HotReload;
        private System.Windows.Forms.Button SwitchtoCartesianButton;
        private System.Windows.Forms.Button GraphButton;
        private System.Windows.Forms.NumericUpDown PeriodNum;
        private System.Windows.Forms.Label label1;
    }
}
