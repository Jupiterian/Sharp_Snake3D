namespace TochilinaAnna
{
    partial class Grid
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveGameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ratingPlayersDataSet = new TochilinaAnna.RatingPlayersDataSet();
            this.save_gameTableAdapter = new TochilinaAnna.RatingPlayersDataSetTableAdapters.Save_gameTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.ratingPlayersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rating_playersTableAdapter = new TochilinaAnna.RatingPlayersDataSetTableAdapters.Rating_playersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveGameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingPlayersDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingPlayersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(540, 261);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // saveGameBindingSource
            // 
            this.saveGameBindingSource.DataMember = "Save game";
            this.saveGameBindingSource.DataSource = this.ratingPlayersDataSet;
            // 
            // ratingPlayersDataSet
            // 
            this.ratingPlayersDataSet.DataSetName = "RatingPlayersDataSet";
            this.ratingPlayersDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // save_gameTableAdapter
            // 
            this.save_gameTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(540, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data does not exist";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // ratingPlayersBindingSource
            // 
            this.ratingPlayersBindingSource.DataMember = "Rating players";
            this.ratingPlayersBindingSource.DataSource = this.ratingPlayersDataSet;
            // 
            // rating_playersTableAdapter
            // 
            this.rating_playersTableAdapter.ClearBeforeFill = true;
            // 
            // Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Grid";
            this.Text = "Database information";
            this.Load += new System.EventHandler(this.Grid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveGameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingPlayersDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingPlayersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private RatingPlayersDataSet ratingPlayersDataSet;
        private System.Windows.Forms.BindingSource saveGameBindingSource;
        private RatingPlayersDataSetTableAdapters.Save_gameTableAdapter save_gameTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource ratingPlayersBindingSource;
        private RatingPlayersDataSetTableAdapters.Rating_playersTableAdapter rating_playersTableAdapter;
    }
}