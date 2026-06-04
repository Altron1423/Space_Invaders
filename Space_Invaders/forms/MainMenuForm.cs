using Space_Invaders.forms;

namespace Space_Invaders
{
    public partial class MainMenuForm : BaseForm
    {
        public MainMenuForm()
        {
            InitializeComponent();
            //Фиксируем размер и внешний вид формы
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            // Устанавливаем стартовую позицию (будет переопределено при открытии из Form1)
            StartPosition = FormStartPosition.Manual;
            if (Screen.PrimaryScreen != null)
            {
                this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
                this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            }
            _moveBackColor = Color.Firebrick;
            _moveForeColor = Color.FromArgb(255, 64, 64, 64);
            _leaveBackColor = Color.Maroon;
            _leaveForeColor = Color.White;
            getHightScore();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form1 form1 = new Form1();

            //form1.StartPosition = FormStartPosition.Manual;
            //form1.Location = new Point(
            //    this.Location.X + (this.Width - form1.Width) / 2,
            //    this.Location.Y + (this.Height - form1.Height) / 2
            //);

            //this.Hide();
            //form1.ShowDialog();
            //this.Close();

            DifficultForm difficultForm = new DifficultForm();
            difficultForm.StartPosition = FormStartPosition.Manual;
            difficultForm.Location = new Point(
                Location.X + (Width - difficultForm.Width) / 2,
                Location.Y + (Height - difficultForm.Height) / 2
            );
            Hide();
            difficultForm.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var otvet = MessageBox.Show("Вы уверены, что хотите выйти?", "Space Invaders", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (otvet == DialogResult.Yes)
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


        private void button3_Click(object sender, EventArgs e)
        {
            ControleForm controleForm = new ControleForm(); // Передаём ссылку на Form2
            controleForm.StartPosition = FormStartPosition.Manual;
            controleForm.Location = new Point(
                Location.X + (Width - controleForm.Width) / 2,
                Location.Y + (Height - controleForm.Height) / 2
            );
            Hide(); // Скрываем Form2
            controleForm.ShowDialog(); // Открываем Form3 в модальном режиме
                                // Close() убран — Form2 не закрывается
            Show(); // Показываем Form2 снова после закрытия Form3
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm(); // Передаём ссылку на Form2
            infoForm.StartPosition = FormStartPosition.Manual;
            infoForm.Location = new Point(
                Location.X + (Width - infoForm.Width) / 2,
                Location.Y + (Height - infoForm.Height) / 2
            );
            Hide(); // Скрываем Form2
            infoForm.ShowDialog(); // Открываем Form5 в модальном режиме
                                // Close() убран — Form2 не закрывается
            Show(); // Показываем Form2 снова после закрытия Form5
        }
    }
}
