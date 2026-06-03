
namespace Space_Invaders.forms
{
    public partial class InfoForm : BaseForm
    {
        public InfoForm()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

    }
}
