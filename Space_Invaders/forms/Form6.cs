using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Invaders.forms
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.StartPosition = FormStartPosition.Manual;
            if (Screen.PrimaryScreen != null)
            {
                this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
                this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.DarkGreen;
            bt.ForeColor = Color.FromArgb(255, 192, 0, 0);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.FromArgb(255, 0, 64, 0);
            bt.ForeColor = Color.Maroon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.StartPosition = FormStartPosition.Manual;
            form1.Location = new Point(
                Location.X + (Width - form1.Width) / 2,
                Location.Y + (Height - form1.Height) / 2
            );
            Hide();
            form1.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = new Point(
                Location.X + (Width - form2.Width) / 2,
                Location.Y + (Height - form2.Height) / 2
            );
            Hide();
            form2.ShowDialog();
            Close();
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.Maroon;
            bt.ForeColor = Color.White;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.Firebrick;
            bt.ForeColor = Color.Black;
        }
    }
}
