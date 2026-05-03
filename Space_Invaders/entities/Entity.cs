namespace Space_Invaders;

public abstract partial class Entity : UserControl
{
    protected int _health;
    protected int _speed;
    protected int _cooldown;
    protected int _cooldownTime = 0;
    protected int _moveOrientation;
    protected Brush _brush;
    protected int _left_border = 0;
    protected int _right_border = 0;
    
    public Entity()
    {
        InitializeComponent();
    }

    public void SetBorder(int leftBorder, int rightBorder)
    {
        _left_border = leftBorder;
        _right_border = rightBorder;
    }
    
    protected virtual void Init() {}

    protected void Draw(object sender, PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;
        graphics.FillRectangle(_brush, 0, 0, Width - 1, Height - 1);
    }
    
    protected void Moving()
    {
        Console.WriteLine($"{_moveOrientation}, {_speed}");
        if (_moveOrientation == -1)
        {
            if (Left > _left_border + _speed)
                Left -= _speed;
            else
                Left = _left_border;
        }
        else if (_moveOrientation == 1)
        {
            if (Left + Width < _right_border - _speed)
                Left += _speed;
            else 
                Left = _right_border - Width;
        }
        Console.WriteLine(Left);
    }
    
    
    public virtual void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
            Die();
    }

    public abstract void Die();
}
