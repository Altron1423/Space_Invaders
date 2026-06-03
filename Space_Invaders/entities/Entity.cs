namespace Space_Invaders;
using System.Diagnostics;

public enum EnemyMove { Normal, Left, Right }

public abstract partial class Entity : UserControl
{
    protected int _health = 2;
    protected int _speed;
    protected int _moveOrientation;
    protected Brush _brush;
    protected int _left_border = 0;
    protected int _right_border = 0;
    protected bool _shoot = false;
    protected EnemyMove _movePosition = EnemyMove.Normal;
    protected readonly Stopwatch _cooldownTimer = new ();
    protected TimeSpan _cooldownDuration;
    
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
        // Console.WriteLine($"{Width - 1}, {Height - 1}");
        graphics.FillRectangle(_brush, 0, 0, Width - 1, Height - 1);
    }

    public virtual void Update()
    {
        // if (_health <= 0)
        // {
        //     Die();
        //     return;
        // }
        Moving();
    }
    
    protected void Moving()
    {
        if (_moveOrientation == -1)
        {
            if (Left > _left_border + _speed)
            {
                Left -= _speed;
                _movePosition = EnemyMove.Normal;
            }
            else
            {
                Left = _left_border;
                _movePosition = EnemyMove.Left;
            }
                
        }
        else if (_moveOrientation == 1)
        {
            if (Left + Width < _right_border - _speed)
            {
                Left += _speed;
                _movePosition = EnemyMove.Normal;
            }
            else
            {
                Left = _right_border - Width;
                _movePosition = EnemyMove.Right;
            }
                
        }
    }
    
    
    public virtual void TakeDamage(int amount)
    {
        _health -= amount;
        // Console.WriteLine($"{Width}x{Height}: {amount} damage ({_health})");
        if (_health <= 0)
            Die();
    }

    public abstract void Die();

    public bool Shoot
    {
        get
        {
            bool value = _shoot;
            _shoot = false;
            return value;
        }
    }

    public int Health
    {
        get { return _health; }
    }
}
