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
    public partial class Form3 : BaseForm
    {
        private Form _parentForm;

        public Form3(Form parentForm)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            _parentForm = parentForm;

            this.StartPosition = FormStartPosition.Manual;
            if (Screen.PrimaryScreen != null)
            {
                this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
                this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            }
            
            _moveBackColor = Color.Firebrick;
            _moveForeColor = Color.FromArgb(255, 64, 64, 64);
            _leaveBackColor = Color.Maroon;
            _leaveForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            _parentForm.Show();
            this.Close();
            //Form2 form2 = new Form2();
            //form2.StartPosition = FormStartPosition.Manual;
            //form2.Location = new Point(
            //    Location.X + (Width - form2.Width) / 2,
            //    Location.Y + (Height - form2.Height) / 2
            //);
            //Hide();
            //form2.ShowDialog();
            //Close();
        }

        // private void button1_MouseMove(object sender, MouseEventArgs e)
        // {
        //     Button bt = sender as Button;
        //     bt.BackColor = 
        //     bt.ForeColor = 
        // }
        //
        // private void button1_MouseLeave(object sender, EventArgs e)
        // {
        //     Button bt = sender as Button;
        //     bt.BackColor = Color.Maroon;
        //     bt.ForeColor = Color.White;
        // }
    }
}
