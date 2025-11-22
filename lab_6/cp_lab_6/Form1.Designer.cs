namespace cp_lab_6
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
            this.DimentionUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MatrixAView = new System.Windows.Forms.DataGridView();
            this.MatrixCView = new System.Windows.Forms.DataGridView();
            this.VectorBView = new System.Windows.Forms.DataGridView();
            this.VectorXView = new System.Windows.Forms.DataGridView();
            this.SolveButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MethodComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DimentionUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixAView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixCView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VectorBView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VectorXView)).BeginInit();
            this.SuspendLayout();
            // 
            // DimentionUpDown
            // 
            this.DimentionUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DimentionUpDown.Location = new System.Drawing.Point(38, 36);
            this.DimentionUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DimentionUpDown.Name = "DimentionUpDown";
            this.DimentionUpDown.Size = new System.Drawing.Size(120, 29);
            this.DimentionUpDown.TabIndex = 0;
            this.DimentionUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DimentionUpDown.ValueChanged += new System.EventHandler(this.DimentionUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введіть розмір матриці";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(135, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "A";
            // 
            // MatrixAView
            // 
            this.MatrixAView.AllowUserToAddRows = false;
            this.MatrixAView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MatrixAView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.MatrixAView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatrixAView.ColumnHeadersVisible = false;
            this.MatrixAView.Location = new System.Drawing.Point(38, 102);
            this.MatrixAView.Name = "MatrixAView";
            this.MatrixAView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.MatrixAView.RowHeadersVisible = false;
            this.MatrixAView.Size = new System.Drawing.Size(240, 150);
            this.MatrixAView.TabIndex = 3;
            this.MatrixAView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MatrixAView_CellClick);
            // 
            // MatrixCView
            // 
            this.MatrixCView.AllowUserToAddRows = false;
            this.MatrixCView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MatrixCView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.MatrixCView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatrixCView.ColumnHeadersVisible = false;
            this.MatrixCView.Location = new System.Drawing.Point(38, 281);
            this.MatrixCView.Name = "MatrixCView";
            this.MatrixCView.ReadOnly = true;
            this.MatrixCView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.MatrixCView.RowHeadersVisible = false;
            this.MatrixCView.Size = new System.Drawing.Size(240, 150);
            this.MatrixCView.TabIndex = 4;
            // 
            // VectorBView
            // 
            this.VectorBView.AllowUserToAddRows = false;
            this.VectorBView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.VectorBView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.VectorBView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VectorBView.ColumnHeadersVisible = false;
            this.VectorBView.Location = new System.Drawing.Point(370, 102);
            this.VectorBView.Name = "VectorBView";
            this.VectorBView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.VectorBView.RowHeadersVisible = false;
            this.VectorBView.Size = new System.Drawing.Size(84, 150);
            this.VectorBView.TabIndex = 5;
            this.VectorBView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VectorBView_CellClick);
            // 
            // VectorXView
            // 
            this.VectorXView.AllowUserToAddRows = false;
            this.VectorXView.AllowUserToDeleteRows = false;
            this.VectorXView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.VectorXView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.VectorXView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VectorXView.ColumnHeadersVisible = false;
            this.VectorXView.Location = new System.Drawing.Point(542, 102);
            this.VectorXView.Name = "VectorXView";
            this.VectorXView.ReadOnly = true;
            this.VectorXView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.VectorXView.RowHeadersVisible = false;
            this.VectorXView.Size = new System.Drawing.Size(84, 150);
            this.VectorXView.TabIndex = 6;
            // 
            // SolveButton
            // 
            this.SolveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SolveButton.Location = new System.Drawing.Point(521, 296);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(127, 43);
            this.SolveButton.TabIndex = 7;
            this.SolveButton.Text = "Розв\'язати";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.Location = new System.Drawing.Point(440, 373);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(127, 43);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "Закрити";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.Location = new System.Drawing.Point(344, 296);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(126, 43);
            this.ClearButton.TabIndex = 9;
            this.ClearButton.Text = "Очистити";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(399, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(572, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(135, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "C";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(311, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 31);
            this.label6.TabIndex = 13;
            this.label6.Text = "+";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(484, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 31);
            this.label7.TabIndex = 14;
            this.label7.Text = "=";
            // 
            // MethodComboBox
            // 
            this.MethodComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MethodComboBox.FormattingEnabled = true;
            this.MethodComboBox.Items.AddRange(new object[] {
            "LU Декомпозиція",
            "Гаус"});
            this.MethodComboBox.Location = new System.Drawing.Point(220, 36);
            this.MethodComboBox.Name = "MethodComboBox";
            this.MethodComboBox.Size = new System.Drawing.Size(294, 28);
            this.MethodComboBox.TabIndex = 15;
            this.MethodComboBox.Text = "Виберіть метод розв\'язання СЛАР";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 450);
            this.Controls.Add(this.MethodComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SolveButton);
            this.Controls.Add(this.VectorXView);
            this.Controls.Add(this.VectorBView);
            this.Controls.Add(this.MatrixCView);
            this.Controls.Add(this.MatrixAView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DimentionUpDown);
            this.Name = "Form1";
            this.Text = "LU transformation";
            ((System.ComponentModel.ISupportInitialize)(this.DimentionUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixAView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixCView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VectorBView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VectorXView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown DimentionUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView MatrixAView;
        private System.Windows.Forms.DataGridView MatrixCView;
        private System.Windows.Forms.DataGridView VectorBView;
        private System.Windows.Forms.DataGridView VectorXView;
        private System.Windows.Forms.Button SolveButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox MethodComboBox;
    }
}

