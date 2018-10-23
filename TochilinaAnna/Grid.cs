using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TochilinaAnna
{
    public partial class Grid : Form
    {
        public String name;
        public int code;
        public Grid()
        {
            InitializeComponent();
            code = 0;
            name = "";
        }

        private void Grid_Load(object sender, EventArgs e)
        {
            this.rating_playersTableAdapter.Fill(this.ratingPlayersDataSet.Rating_players);
            dataGridView1.DataSource = null;

            switch (code) {
                case 0:
                    dataGridView1.DataSource = ratingPlayersBindingSource;
                    this.rating_playersTableAdapter.Fill(this.ratingPlayersDataSet.Rating_players);
                    break;
                case 1:
                    dataGridView1.DataSource = saveGameBindingSource;
                    this.save_gameTableAdapter.Fill(this.ratingPlayersDataSet.Save_game);
                    saveGameBindingSource.Filter = "Name = '"+name+"'";
                    break;
            }

            dataGridView1.Update();

            if (dataGridView1.RowCount == 0)
            {
                label1.Visible = true;
                dataGridView1.Visible = false;
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(code == 1)
            { 
                //dataGridView1.RowCount
                //e.RowIndex
            }

            //MessageBox.Show("df");
            this.Close();
        }
    }
}
