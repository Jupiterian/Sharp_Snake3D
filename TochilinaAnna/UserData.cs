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
    public partial class UserData : Form
    {
        public String name;
        public int fieldX, fieldY;

        public UserData()
        {
            InitializeComponent();
        }

        private void buttonOk_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBoxUserName.Text == "")
            {
                MessageBox.Show("Enter your data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\RatingPlayers.mdb";
            OleDbCommand command = new OleDbCommand();
            command.CommandText = "INSERT INTO [Players] (Name) VALUES('" + textBoxUserName.Text + "');";
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

                //name = textBoxUserName.Text;
                //buttonOk.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("This user already exists", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //textBoxUserName.Text = "";
            }
            finally
            {
                name = textBoxUserName.Text; //

                int ind = comboBox1.Text.IndexOf('x');
                fieldX = Convert.ToInt32(comboBox1.Text.Substring(0, ind - 1));
                fieldY = Convert.ToInt32(comboBox1.Text.Substring(ind + 1));

                buttonOk.DialogResult = DialogResult.OK; //
                connection.Close();
            }
        }
    }
}
