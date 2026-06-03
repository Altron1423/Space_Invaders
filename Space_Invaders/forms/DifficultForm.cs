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
    public partial class DifficultForm : BaseForm
    {
        public DifficultForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            StartPosition = FormStartPosition.Manual;
            if (Screen.PrimaryScreen != null)
            {
                Left = (Screen.PrimaryScreen.WorkingArea.Width - Width) / 2;
                Top = (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2;
            }
            _moveBackColor = Color.Firebrick;
            _moveForeColor = Color.FromArgb(255, 64, 64, 64);
            _leaveBackColor = Color.Maroon;
            _leaveForeColor = Color.White;
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
            int dificlty = (sender as Button).Text.Length / 2;
            GameForm gameForm = new GameForm(dificlty);
            gameForm.StartPosition = FormStartPosition.Manual;
            gameForm.Location = new Point(
                Location.X + (Width - gameForm.Width) / 2,
                Location.Y + (Height - gameForm.Height) / 2
            );
            Hide();
            gameForm.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.StartPosition = FormStartPosition.Manual;
            mainMenuForm.Location = new Point(
                Location.X + (Width - mainMenuForm.Width) / 2,
                Location.Y + (Height - mainMenuForm.Height) / 2
            );
            Hide();
            mainMenuForm.ShowDialog();
            Close();
        }

    }
}
