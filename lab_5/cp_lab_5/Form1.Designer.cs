namespace cp_lab_5
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.solve = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.ABox = new System.Windows.Forms.TextBox();
            this.EpsBox = new System.Windows.Forms.TextBox();
            this.BBox = new System.Windows.Forms.TextBox();
            this.RootBox = new System.Windows.Forms.TextBox();
            this.IterBox = new System.Windows.Forms.TextBox();
            this.KmaxBox = new System.Windows.Forms.TextBox();
            this.BisectionRadio = new System.Windows.Forms.RadioButton();
            this.NewtonRadio = new System.Windows.Forms.RadioButton();
            this.F1Radio = new System.Windows.Forms.RadioButton();
            this.F2Radio = new System.Windows.Forms.RadioButton();
            this.F3Radio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FuncChoice = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.FuncChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Вхідні дані";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "а";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "b";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "eps";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "kmax";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(407, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Результати";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(356, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Корінь";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(352, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Ітерації";
            // 
            // solve
            // 
            this.solve.Location = new System.Drawing.Point(341, 187);
            this.solve.Name = "solve";
            this.solve.Size = new System.Drawing.Size(75, 23);
            this.solve.TabIndex = 12;
            this.solve.Text = "Розв\'язати";
            this.solve.UseVisualStyleBackColor = true;
            this.solve.Click += new System.EventHandler(this.solve_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(450, 187);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 13;
            this.clear.Text = "Очистити";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(397, 232);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 14;
            this.exit.Text = "Закрити";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // ABox
            // 
            this.ABox.Location = new System.Drawing.Point(225, 59);
            this.ABox.Name = "ABox";
            this.ABox.Size = new System.Drawing.Size(100, 20);
            this.ABox.TabIndex = 15;
            // 
            // EpsBox
            // 
            this.EpsBox.Location = new System.Drawing.Point(225, 111);
            this.EpsBox.Name = "EpsBox";
            this.EpsBox.Size = new System.Drawing.Size(100, 20);
            this.EpsBox.TabIndex = 16;
            // 
            // BBox
            // 
            this.BBox.Location = new System.Drawing.Point(225, 85);
            this.BBox.Name = "BBox";
            this.BBox.Size = new System.Drawing.Size(100, 20);
            this.BBox.TabIndex = 17;
            // 
            // RootBox
            // 
            this.RootBox.Location = new System.Drawing.Point(397, 59);
            this.RootBox.Name = "RootBox";
            this.RootBox.ReadOnly = true;
            this.RootBox.Size = new System.Drawing.Size(100, 20);
            this.RootBox.TabIndex = 20;
            // 
            // IterBox
            // 
            this.IterBox.Location = new System.Drawing.Point(397, 112);
            this.IterBox.Name = "IterBox";
            this.IterBox.ReadOnly = true;
            this.IterBox.Size = new System.Drawing.Size(100, 20);
            this.IterBox.TabIndex = 19;
            // 
            // KmaxBox
            // 
            this.KmaxBox.Location = new System.Drawing.Point(225, 137);
            this.KmaxBox.Name = "KmaxBox";
            this.KmaxBox.Size = new System.Drawing.Size(100, 20);
            this.KmaxBox.TabIndex = 18;
            // 
            // BisectionRadio
            // 
            this.BisectionRadio.AutoSize = true;
            this.BisectionRadio.Location = new System.Drawing.Point(15, 19);
            this.BisectionRadio.Name = "BisectionRadio";
            this.BisectionRadio.Size = new System.Drawing.Size(101, 17);
            this.BisectionRadio.TabIndex = 21;
            this.BisectionRadio.TabStop = true;
            this.BisectionRadio.Text = "Ділення навпіл";
            this.BisectionRadio.UseVisualStyleBackColor = true;
            // 
            // NewtonRadio
            // 
            this.NewtonRadio.AutoSize = true;
            this.NewtonRadio.Location = new System.Drawing.Point(15, 42);
            this.NewtonRadio.Name = "NewtonRadio";
            this.NewtonRadio.Size = new System.Drawing.Size(70, 17);
            this.NewtonRadio.TabIndex = 22;
            this.NewtonRadio.TabStop = true;
            this.NewtonRadio.Text = "Ньютона";
            this.NewtonRadio.UseVisualStyleBackColor = true;
            // 
            // F1Radio
            // 
            this.F1Radio.AutoSize = true;
            this.F1Radio.Location = new System.Drawing.Point(15, 19);
            this.F1Radio.Name = "F1Radio";
            this.F1Radio.Size = new System.Drawing.Size(75, 17);
            this.F1Radio.TabIndex = 24;
            this.F1Radio.TabStop = true;
            this.F1Radio.Text = "x^2 - 4 = 0";
            this.F1Radio.UseVisualStyleBackColor = true;
            // 
            // F2Radio
            // 
            this.F2Radio.AutoSize = true;
            this.F2Radio.Location = new System.Drawing.Point(15, 42);
            this.F2Radio.Name = "F2Radio";
            this.F2Radio.Size = new System.Drawing.Size(100, 17);
            this.F2Radio.TabIndex = 23;
            this.F2Radio.TabStop = true;
            this.F2Radio.Text = "3x - 4ln(x) -5 = 0";
            this.F2Radio.UseVisualStyleBackColor = true;
            // 
            // F3Radio
            // 
            this.F3Radio.AutoSize = true;
            this.F3Radio.Location = new System.Drawing.Point(15, 65);
            this.F3Radio.Name = "F3Radio";
            this.F3Radio.Size = new System.Drawing.Size(74, 17);
            this.F3Radio.TabIndex = 25;
            this.F3Radio.TabStop = true;
            this.F3Radio.Text = "e^x-3x = 0";
            this.F3Radio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BisectionRadio);
            this.groupBox1.Controls.Add(this.NewtonRadio);
            this.groupBox1.Location = new System.Drawing.Point(30, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 73);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Оберіть Метод";
            // 
            // FuncChoice
            // 
            this.FuncChoice.Controls.Add(this.F1Radio);
            this.FuncChoice.Controls.Add(this.F2Radio);
            this.FuncChoice.Controls.Add(this.F3Radio);
            this.FuncChoice.Location = new System.Drawing.Point(30, 122);
            this.FuncChoice.Name = "FuncChoice";
            this.FuncChoice.Size = new System.Drawing.Size(128, 88);
            this.FuncChoice.TabIndex = 27;
            this.FuncChoice.TabStop = false;
            this.FuncChoice.Text = "Оберіть Рівняння";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 282);
            this.Controls.Add(this.FuncChoice);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RootBox);
            this.Controls.Add(this.IterBox);
            this.Controls.Add(this.KmaxBox);
            this.Controls.Add(this.BBox);
            this.Controls.Add(this.EpsBox);
            this.Controls.Add(this.ABox);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.solve);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Name = "Form1";
            this.Text = "Розв\'язання нелінійних рівнянь методами МДН та МН";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.FuncChoice.ResumeLayout(false);
            this.FuncChoice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button solve;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.TextBox ABox;
        private System.Windows.Forms.TextBox EpsBox;
        private System.Windows.Forms.TextBox BBox;
        private System.Windows.Forms.TextBox RootBox;
        private System.Windows.Forms.TextBox IterBox;
        private System.Windows.Forms.TextBox KmaxBox;
        private System.Windows.Forms.RadioButton BisectionRadio;
        private System.Windows.Forms.RadioButton NewtonRadio;
        private System.Windows.Forms.RadioButton F1Radio;
        private System.Windows.Forms.RadioButton F2Radio;
        private System.Windows.Forms.RadioButton F3Radio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox FuncChoice;
    }
}

