namespace cp_lab_12
{
    partial class ApproxView
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
            this.SwitchToCartesianButton = new System.Windows.Forms.Button();
            this.SwitchToPolarButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ApproxTypeSelect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ApproxDegree = new System.Windows.Forms.NumericUpDown();
            this.HotReloadEnabler = new System.Windows.Forms.CheckBox();
            this.ApproximateButton = new System.Windows.Forms.Button();
            this.LoadCsvButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ApproxDegree)).BeginInit();
            this.SuspendLayout();
            // 
            // SwitchToCartesianButton
            // 
            this.SwitchToCartesianButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SwitchToCartesianButton.Location = new System.Drawing.Point(7, 408);
            this.SwitchToCartesianButton.Name = "SwitchToCartesianButton";
            this.SwitchToCartesianButton.Size = new System.Drawing.Size(159, 32);
            this.SwitchToCartesianButton.TabIndex = 38;
            this.SwitchToCartesianButton.Text = "Open Cartesian";
            this.SwitchToCartesianButton.UseVisualStyleBackColor = true;
            this.SwitchToCartesianButton.Click += new System.EventHandler(this.SwitchToCartesianButton_Click);
            // 
            // SwitchToPolarButton
            // 
            this.SwitchToPolarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SwitchToPolarButton.Location = new System.Drawing.Point(7, 370);
            this.SwitchToPolarButton.Name = "SwitchToPolarButton";
            this.SwitchToPolarButton.Size = new System.Drawing.Size(159, 32);
            this.SwitchToPolarButton.TabIndex = 37;
            this.SwitchToPolarButton.Text = "Open Polar";
            this.SwitchToPolarButton.UseVisualStyleBackColor = true;
            this.SwitchToPolarButton.Click += new System.EventHandler(this.SwitchToPolarButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Approximation Type";
            // 
            // ApproxTypeSelect
            // 
            this.ApproxTypeSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApproxTypeSelect.FormattingEnabled = true;
            this.ApproxTypeSelect.Items.AddRange(new object[] {
            "Linear",
            "Non-Linear"});
            this.ApproxTypeSelect.Location = new System.Drawing.Point(4, 23);
            this.ApproxTypeSelect.Name = "ApproxTypeSelect";
            this.ApproxTypeSelect.Size = new System.Drawing.Size(121, 28);
            this.ApproxTypeSelect.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Approximation degree";
            // 
            // ApproxDegree
            // 
            this.ApproxDegree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApproxDegree.Location = new System.Drawing.Point(7, 112);
            this.ApproxDegree.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ApproxDegree.Name = "ApproxDegree";
            this.ApproxDegree.Size = new System.Drawing.Size(120, 26);
            this.ApproxDegree.TabIndex = 33;
            this.ApproxDegree.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // HotReloadEnabler
            // 
            this.HotReloadEnabler.AutoSize = true;
            this.HotReloadEnabler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HotReloadEnabler.Location = new System.Drawing.Point(7, 264);
            this.HotReloadEnabler.Name = "HotReloadEnabler";
            this.HotReloadEnabler.Size = new System.Drawing.Size(109, 24);
            this.HotReloadEnabler.TabIndex = 32;
            this.HotReloadEnabler.Text = "Hot Reload";
            this.HotReloadEnabler.UseVisualStyleBackColor = true;
            this.HotReloadEnabler.CheckedChanged += new System.EventHandler(this.HotReloadEnabler_CheckedChanged);
            // 
            // ApproximateButton
            // 
            this.ApproximateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApproximateButton.Location = new System.Drawing.Point(7, 332);
            this.ApproximateButton.Name = "ApproximateButton";
            this.ApproximateButton.Size = new System.Drawing.Size(159, 32);
            this.ApproximateButton.TabIndex = 31;
            this.ApproximateButton.Text = "Approximate";
            this.ApproximateButton.UseVisualStyleBackColor = true;
            this.ApproximateButton.Click += new System.EventHandler(this.ApproximateButton_Click);
            // 
            // LoadCsvButton
            // 
            this.LoadCsvButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadCsvButton.Location = new System.Drawing.Point(7, 294);
            this.LoadCsvButton.Name = "LoadCsvButton";
            this.LoadCsvButton.Size = new System.Drawing.Size(159, 32);
            this.LoadCsvButton.TabIndex = 30;
            this.LoadCsvButton.Text = "Load csv";
            this.LoadCsvButton.UseVisualStyleBackColor = true;
            this.LoadCsvButton.Click += new System.EventHandler(this.LoadCsvButton_Click);
            // 
            // ApproxView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SwitchToCartesianButton);
            this.Controls.Add(this.SwitchToPolarButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ApproxTypeSelect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ApproxDegree);
            this.Controls.Add(this.HotReloadEnabler);
            this.Controls.Add(this.ApproximateButton);
            this.Controls.Add(this.LoadCsvButton);
            this.Name = "ApproxView";
            this.Size = new System.Drawing.Size(195, 450);
            ((System.ComponentModel.ISupportInitialize)(this.ApproxDegree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SwitchToCartesianButton;
        private System.Windows.Forms.Button SwitchToPolarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ApproxTypeSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ApproxDegree;
        private System.Windows.Forms.CheckBox HotReloadEnabler;
        private System.Windows.Forms.Button ApproximateButton;
        private System.Windows.Forms.Button LoadCsvButton;
    }
}
