namespace Space_Invaders.forms;

public partial class BaseForm : Form
{
    protected Color _moveBackColor;
    protected Color _moveForeColor;
    protected Color _leaveBackColor;
    protected Color _leaveForeColor;
    
    
    public BaseForm()
    {
        InitializeComponent();
    }
    
    protected virtual void button_MouseMove(object sender, MouseEventArgs e)
    {
        Button bt = sender as Button;
        Console.WriteLine($"{_moveBackColor} {_moveForeColor}");
        // bt.BackColor = Color.DarkGreen;
        // bt.ForeColor = Color.FromArgb(255, 192, 0, 0);
        bt.BackColor = _moveBackColor;
        bt.ForeColor = _moveForeColor;
    }

    protected virtual void button_MouseLeave(object sender, EventArgs e)
    {
        Button bt = sender as Button;
        Console.WriteLine($"{_leaveBackColor} {_leaveForeColor}");
        // bt.BackColor = Color.FromArgb(255, 0, 64, 0);
        // bt.ForeColor = Color.Maroon;
        bt.BackColor = _leaveBackColor;
        bt.ForeColor = _leaveForeColor;
    }

}