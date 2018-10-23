namespace TochilinaAnna
{
    partial class DiagramForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiagramForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            //this.axActiveXGradientButton1 = new AxActiveXGradientButtonLib.AxActiveXGradientButton();
            this.menuStrip1.SuspendLayout();
           // ((System.ComponentModel.ISupportInitialize)(this.axActiveXGradientButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(493, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.colorsToolStripMenuItem.Text = "Colors";
            this.colorsToolStripMenuItem.Click += new System.EventHandler(this.colorsToolStripMenuItem_Click);
            // 
            // axActiveXGradientButton1
            // 
           /* this.axActiveXGradientButton1.Location = new System.Drawing.Point(378, 352);
            this.axActiveXGradientButton1.Name = "axActiveXGradientButton1";
            this.axActiveXGradientButton1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axActiveXGradientButton1.OcxState")));
            this.axActiveXGradientButton1.Size = new System.Drawing.Size(103, 29);
            this.axActiveXGradientButton1.TabIndex = 1;
            this.axActiveXGradientButton1.LeftMouseClick += new System.EventHandler(this.axActiveXGradientButton1_LeftMouseClick);
            */
            // 
            // DiagramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 393);
            //this.Controls.Add(this.axActiveXGradientButton1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DiagramForm";
            this.Text = "DiagramForm";
            this.Load += new System.EventHandler(this.DiagramForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DiagramForm_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DiagramForm_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            //((System.ComponentModel.ISupportInitialize)(this.axActiveXGradientButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        //private AxActiveXGradientButtonLib.AxActiveXGradientButton axActiveXGradientButton1;
    }
}