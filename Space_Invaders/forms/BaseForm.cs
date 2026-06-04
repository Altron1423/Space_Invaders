namespace Space_Invaders.forms;

public partial class BaseForm : Form
{
    protected Color _moveBackColor;
    protected Color _moveForeColor;
    protected Color _leaveBackColor;
    protected Color _leaveForeColor;
    
    private static string saveDirectory = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "SpaceInvaders"
        );
    private string saveFilePath = Path.Combine(saveDirectory, "highscore.txt");
    
    
    public BaseForm()
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
            Left = (Screen.PrimaryScreen.WorkingArea.Width - Width) / 2;
            Top = (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2;
        }
        _moveBackColor = Color.Firebrick;
        _moveForeColor = Color.FromArgb(255, 64, 64, 64);
        _leaveBackColor = Color.Maroon;
        _leaveForeColor = Color.White;
    }
    
    protected virtual void button_MouseMove(object sender, MouseEventArgs e)
    {
        Button bt = sender as Button;
        // Console.WriteLine($"{_moveBackColor} {_moveForeColor}");
        // bt.BackColor = Color.DarkGreen;
        // bt.ForeColor = Color.FromArgb(255, 192, 0, 0);
        bt.BackColor = _moveBackColor;
        bt.ForeColor = _moveForeColor;
    }

    protected virtual void button_MouseLeave(object sender, EventArgs e)
    {
        Button bt = sender as Button;
        // Console.WriteLine($"{_leaveBackColor} {_leaveForeColor}");
        // bt.BackColor = Color.FromArgb(255, 0, 64, 0);
        // bt.ForeColor = Color.Maroon;
        bt.BackColor = _leaveBackColor;
        bt.ForeColor = _leaveForeColor;
    }

    protected int getHightScore()
    {
        checkDirection();
        try
        {
            return int.Parse(File.ReadAllText(saveFilePath));
        }
        catch (Exception ex)
        {
            // MessageBox.Show("Ошибка чтения: " + ex.Message);
        }
        return 0;
    }

    protected void setHightScore(int score)
    {
        checkDirection();
        if (score < getHightScore())
            return;
        File.WriteAllText(saveFilePath, score.ToString());
    }

    private void checkDirection()
    {
        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }
    }
}