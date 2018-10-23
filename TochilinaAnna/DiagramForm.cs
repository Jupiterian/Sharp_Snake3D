using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace TochilinaAnna
{
    public partial class DiagramForm : Form
    {
        Pen pen;
        Font f;
        Rectangle rect;
        List<float> values;
        List<Color> colors;
        List<Label> labels;
        int line;
        int padding;

        public DiagramForm()
        {
            InitializeComponent();
            ResizeRedraw = true;
            pen = new Pen(Color.White, line);
            values = new List<float>();
            colors = new List<Color>();
            labels = new List<Label>();
            line = 3;
            padding = 10;
        }

        private void DiagramForm_Paint(object sender, PaintEventArgs e)
        {
            float total = 0;
            float sweepAngle, startAngle = 0;

            if (ClientSize.Width <= 200 || ClientSize.Height <= 200) return;
            //if (ClientSize.Width <= line * 2 + padding || ClientSize.Height <= line * 2 + padding) return;
           // axActiveXGradientButton1.Location = new Point(ClientSize.Width - 10 - axActiveXGradientButton1.Width, ClientSize.Height - 10 - axActiveXGradientButton1.Height);
            int DiagramSize = ClientSize.Width < ClientSize.Height ? ClientSize.Width - line : ClientSize.Height - line;
            DiagramSize -= (line + padding);
            rect = new Rectangle(ClientSize.Width / 2 - DiagramSize / 2, ClientSize.Height / 2 - DiagramSize / 2, DiagramSize, DiagramSize);

            if (values.Count == 1)
            {
                Brush br = new SolidBrush(colors[0]);
                e.Graphics.FillEllipse(br, rect);
                e.Graphics.DrawEllipse(pen, rect);

                labels[0].Location = new Point(ClientSize.Width / 2 - 5, ClientSize.Height / 2 - 5);

                br.Dispose();
                return;
            }

            foreach (float val in values)
                total += val;

            f = new Font(FontFamily.GenericSerif, DiagramSize / 25);

            for (int i = 0; i < values.Count; i++)
            {
                Brush br = new SolidBrush(colors[i]);
                sweepAngle = 360 * values[i] / total;
                e.Graphics.FillPie(br, rect, startAngle, sweepAngle);
                e.Graphics.DrawPie(pen, rect, startAngle, sweepAngle);

                double x = Math.Cos((startAngle + sweepAngle / 2) * Math.PI / 180) * DiagramSize / 3;
                double y = Math.Sin((startAngle + sweepAngle / 2) * Math.PI / 180) * DiagramSize / 3;

                SizeF textSize = e.Graphics.MeasureString(labels[i].Text, f);
                labels[i].Font = f;
                labels[i].Location = new Point(ClientSize.Width / 2 + (int)(x - textSize.Width / 2), ClientSize.Height / 2 + (int)(y - textSize.Height / 2));

                startAngle += sweepAngle;
                br.Dispose();
            }
        }

        private void DiagramForm_Load(object sender, EventArgs e)
        {
            foreach (Label lab in labels)
            {
                this.Controls.Remove(lab);
                lab.Dispose();
            }
            labels.Clear();
            values.Clear();


            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\RatingPlayers.mdb";
            OleDbCommand command = new OleDbCommand();
            command.CommandText = "Select Name, [Total score] from [Rating players]";
            command.Connection = connection;
            try
            {
                connection.Open();
                OleDbDataReader dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    int i = 0;
                    while (dr.Read())
                    {
                        double score = Convert.ToDouble(dr["Total score"]);
                        if (score == 0) continue;
                        values.Add((float)score);

                        labels.Add(new Label());
                        this.Controls.Add(labels[i]);
                        labels[i].Text = Convert.ToString(dr["Name"] + ": "+ score);
                        labels[i].BackColor = Color.Transparent;
                        labels[i].AutoSize = true;
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных: " + Environment.NewLine + ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            colorsToolStripMenuItem_Click(sender, e);
        }

        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colors.Clear();
            Random rand = new Random();
            for (int i = 0; i < values.Count; i++)
                colors.Add(Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)));
            Invalidate();
        }

        private void DiagramForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y <= menuStrip1.Size.Height) menuStrip1.Visible = true;
            else menuStrip1.Visible = false;
        }

        private void axActiveXGradientButton1_LeftMouseClick(object sender, EventArgs e)
        {
            colorsToolStripMenuItem_Click(sender, e);
        }
    }
}
