namespace cp_lab_12
{
    partial class ViewManager
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
            this.GraphPicture = new System.Windows.Forms.PictureBox();
            this.ViewPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.GraphPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphPicture
            // 
            this.GraphPicture.Location = new System.Drawing.Point(0, 0);
            this.GraphPicture.Name = "GraphPicture";
            this.GraphPicture.Size = new System.Drawing.Size(604, 450);
            this.GraphPicture.TabIndex = 0;
            this.GraphPicture.TabStop = false;
            // 
            // ViewPanel
            // 
            this.ViewPanel.Location = new System.Drawing.Point(604, 0);
            this.ViewPanel.Name = "ViewPanel";
            this.ViewPanel.Size = new System.Drawing.Size(195, 450);
            this.ViewPanel.TabIndex = 1;
            // 
            // ViewManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ViewPanel);
            this.Controls.Add(this.GraphPicture);
            this.Name = "ViewManager";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GraphPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GraphPicture;
        private System.Windows.Forms.Panel ViewPanel;
    }
}