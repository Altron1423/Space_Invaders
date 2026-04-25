namespace Space_Invaders;

public abstract partial class Entity : UserControl
{
    protected int _health;
    protected int _speed;
    protected int _cooldown;
    protected int _moveOrientation;
    
    public Entity()
    {
        InitializeComponent();
    }
    
    protected virtual void Init() {}

    protected void Moving()
    {
        Console.WriteLine($"{_moveOrientation}, {_speed}");
        if (_moveOrientation == -1)
        {
            if (Left > _speed)
                Left -= _speed;
        }
        else if (_moveOrientation == 1)
        {
            if (Left < Form.ActiveForm.Width - Width - _speed*3)
                Left += _speed;
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
