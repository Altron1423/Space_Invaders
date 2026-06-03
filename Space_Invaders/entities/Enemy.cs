using System.ComponentModel;
using System.Diagnostics;

namespace Space_Invaders;

public enum EnemyType { Normal, Fast, Armored }

public partial class Enemy : Entity
{
    public EnemyType _type;
    public int points = 1;
    public double _shootChance = 15;
    private bool shoot = false;
    private Random _shotRanom = new Random();
    private readonly Stopwatch _cooldownTimer = new ();
    private TimeSpan _cooldownDuration;

    public Enemy(EnemyType type)
    {
        _speed = (new Random()).Next(5, 8);
        _moveOrientation = 1;
        
        _brush = Brushes.Red;
        _type = type;
        if (_type == EnemyType.Armored)
        {
            _health = 3;
        }
        else if (_type == EnemyType.Fast)
        {
            _speed *= 2;
        }
        InitializeComponent();
        _cooldownTimer.Start();
        _cooldownDuration = TimeSpan.FromSeconds(0.5);
    }

    public override void Update()
    {
        base.Update();
        if (_movePosition != EnemyMove.Normal)
        {
            if (_movePosition == EnemyMove.Left)
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
