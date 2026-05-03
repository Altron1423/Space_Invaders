using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var otvet = MessageBox.Show("Вы уверены, что хотите выйти?", "Space Invaders", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (otvet == DialogResult.Yes)
                Application.Exit();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.DarkGreen;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(255, 0, 64, 0);
            button1.ForeColor = Color.White;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.Firebrick;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Maroon;
            button2.ForeColor = Color.White;
        }
    }
}
