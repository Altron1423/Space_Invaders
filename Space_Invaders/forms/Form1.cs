namespace Space_Invaders;

public partial class Form1 : Form
{
    private bool _paused = true;
    
    public Form1()
    {
        InitializeComponent();
        //Фиксируем размер и внешний вид формы
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;

        // Устанавливаем стартовую позицию (будет переопределено при открытии из Form1)
        StartPosition = FormStartPosition.Manual;

        right_fon.FlatAppearance.MouseOverBackColor = right_fon.BackColor;
        left_fon.FlatAppearance.MouseOverBackColor = left_fon.BackColor;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // Устанавливаем фокус на управляемый элемент
        player.Focus();
        KeyPreview = true;

        // Для PictureBox или Panel нужно установить:
        player.TabStop = true; // Разрешить получение фокуса
    }

    private void RunGame(object sender, EventArgs e)
    {
        player.SetBorder(left_fon.Width, right_fon.Left);
        _paused = false;
        
        start_button.Visible = false;
        player.Visible = true;
        right_fon.Visible = true;
        left_fon.Visible = true;
        pause_button.Visible = true;
    }

    private void player_KeyDown(object sender, KeyEventArgs e)
    {
        if (!_paused)
        {
            player.PlayerKeyDown(e);
        }
    }
    private void player_KeyUp(object sender, KeyEventArgs e)
    {
        if (!_paused)
        {
            player.PlayerKeyUp(e);
        }
    }

    private void button_MouseMove(object sender, MouseEventArgs e)
    {
        Button bt = sender as Button;
        if (!(bt == pause_button && _paused))
        {
            bt.BackColor = Color.DarkGreen;
        }
        bt.ForeColor = Color.Black;
    }

    private void button_MouseLeave(object sender, EventArgs e)
    {
        Button bt = sender as Button;
        if (!(bt == pause_button && _paused))
        {
            bt.BackColor = Color.FromArgb(255, 0, 64, 0);
        }
        // bt.BackColor = Color.DarkGreen;
        bt.ForeColor = Color.White;
    }

    private void PauseClick(object sender, EventArgs e)
    {
        if (_paused)
        {// pause off
            continue_button.Visible = false;
            exit_button.Visible = false;
        }
        else
        {// pause on
            pause_button.BackColor = Color.Maroon;
            
            continue_button.Visible = true;
            exit_button.Visible = true;
        }
        _paused = !_paused;
    }

    private void ContinueClick(object sender, EventArgs e)
    {
        continue_button.Visible = false;
        exit_button.Visible = false;
        
        _paused = false;
    }

    private void ButtonExit(object sender, EventArgs e)
    {
        var otvet = MessageBox.Show("Вы уверены, что хотите завершить?", "Space Invaders", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (otvet == DialogResult.Yes)
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
    }
}