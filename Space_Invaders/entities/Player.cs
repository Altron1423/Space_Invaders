using System.ComponentModel;


namespace Space_Invaders;

public partial class Player : Entity
{
    private bool _keyAPress, _keyDPress;
    public Player()
    {
        InitializeComponent();
    }

    public Player(IContainer container)
    {
        container.Add(this);

        InitializeComponent();
    }

    protected override void Init()
    {
        _health = 3;
        _speed = 10;
        _moveOrientation = 0;
        _keyAPress = false;
        _keyDPress = false;
        _cooldown = 10;
        _brush = Brushes.Green;
    }

    public void PlayerKeyUp(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.A)
        {
            _moveOrientation++;
            _keyAPress = false;
        }
        else if (e.KeyCode == Keys.D)
        {
            _moveOrientation--;
            _keyDPress = false;
        }
    }
    
    public void PlayerKeyDown(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.A && !_keyAPress)
        {
            _keyAPress = true;
            _moveOrientation--;
        }
        else if (e.KeyCode == Keys.D && !_keyDPress)
        {
            _keyDPress = true;
            _moveOrientation++;
        }
        else if (e.KeyCode == Keys.Space)
        {
            if (_cooldownTime <= 1)
            {
                _cooldownTime = _cooldown;
                Console.WriteLine($"Shoot {Left + Width / 2}");
            }
        }

        Moving();
    }
    
    public override void Die() {}
}


