using System.ComponentModel;

namespace Space_Invaders;

public enum EnemyType { Normal, Fast, Armored }

public partial class Enemy : Entity
{
    public EnemyType _type;
    public int points = 1;
    public int _shootChance = 35;
    private bool shoot = false;
    private Random _shotRanom = new ();

    public Enemy(EnemyType type)
    {
        _cooldownDuration = TimeSpan.FromSeconds(1);
        _speed = new Random().Next(5, 8);
        _moveOrientation = 1;
        
        _brush = Brushes.Red;
        _type = type;
        if (_type == EnemyType.Armored)
        {
            _health = 3;
            _speed -= 2;
            _brush = Brushes.DarkRed;
        }
        else if (_type == EnemyType.Fast)
        {
            _health = 1;
            _speed += 3;
            _brush = Brushes.DarkBlue;
        }
        InitializeComponent();
        _cooldownTimer.Start();
    }

    public override void Update()
    {
        base.Update();
        if (_movePosition != EntityMove.Normal)
        {
            if (_movePosition == EntityMove.Left)
            {
                _moveOrientation = 1;
            } else 
            {
                _moveOrientation = -1;
            }

            Top += 30;
        }

        if (_cooldownTimer.Elapsed >= _cooldownDuration)
        {
            _cooldownTimer.Restart();
            if (_shotRanom.Next(0, 100) <= _shootChance)
                _shoot = true;
        }
    }

    public override void Die() {}

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Shoot
    {
        get
        {
            bool sh = shoot;
            shoot = false;
            return sh;
        }
    }
}
