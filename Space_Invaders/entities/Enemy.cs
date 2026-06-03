using System.ComponentModel;

namespace Space_Invaders;

public enum EnemyType { Normal, Fast, Armored }

public partial class Enemy : Entity
{
    public EnemyType _type;
    public int points = 1;
    public double _shootChance;

    public Enemy(EnemyType type)
    {
        _speed = (new Random()).Next(5, 8);
        _moveOrientation = 1;
        InitializeComponent();
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
        
    }

    public override void Die() {}

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public EnemyType Type
    {
        get => _type;
        set => _type = value;
    }
}
