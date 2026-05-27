using Space_Invaders.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Invaders
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //Фиксируем размер и внешний вид формы
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Устанавливаем стартовую позицию (будет переопределено при открытии из Form1)
            this.StartPosition = FormStartPosition.Manual;
            if (Screen.PrimaryScreen != null)
            {
                this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
                this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            form1.StartPosition = FormStartPosition.Manual;
            form1.Location = new Point(
                this.Location.X + (this.Width - form1.Width) / 2,
                this.Location.Y + (this.Height - form1.Height) / 2
            );

            this.Hide();
            form1.ShowDialog();
            this.Close();

            //Form6 form6 = new Form6();
            //form6.StartPosition = FormStartPosition.Manual;
            //form6.Location = new Point(
            //    Location.X + (Width - form6.Width) / 2,
            //    Location.Y + (Height - form6.Height) / 2
            //);
            //Hide();
            //form6.ShowDialog();
            //Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var otvet = MessageBox.Show("Вы уверены, что хотите выйти?", "Space Invaders", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (otvet == DialogResult.Yes)
                Application.Exit();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.DarkGreen;
            bt.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.FromArgb(255, 0, 64, 0);
            bt.ForeColor = Color.White;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.Firebrick;
            bt.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.Maroon;
            bt.ForeColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.StartPosition = FormStartPosition.Manual;
            form3.Location = new Point(
                Location.X + (Width - form3.Width) / 2,
                Location.Y + (Height - form3.Height) / 2
            );
            Hide();
            form3.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.StartPosition = FormStartPosition.Manual;
            form5.Location = new Point(
                Location.X + (Width - form5.Width) / 2,
                Location.Y + (Height - form5.Height) / 2
            );
            Hide();
            form5.ShowDialog();
            Close();
        }
    }
}
