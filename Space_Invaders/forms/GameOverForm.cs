
namespace Space_Invaders.forms
{
    public partial class GameOverForm : BaseForm
    {
        private int _start_dificalty;
        
        public GameOverForm(int start_dificalty, int score)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            // Устанавливаем стартовую позицию (будет переопределено при открытии из Form1)
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
            _start_dificalty = start_dificalty;
            label3.Text = $"Счёт: {score}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm(_start_dificalty);
            gameForm.StartPosition = FormStartPosition.Manual;
            gameForm.Location = new Point(
                Location.X + (Width - gameForm.Width) / 2,
                Location.Y + (Height - gameForm.Height) / 2
            );
            Hide();
            gameForm.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.FromArgb(255, 0, 64, 0);
            bt.ForeColor = Color.White;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            bt.BackColor = Color.DarkGreen;
            bt.ForeColor = Color.Black;
        }
    }
}