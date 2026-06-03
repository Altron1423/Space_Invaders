using System.Drawing.Drawing2D;

namespace Space_Invaders;

public partial class Bullet : Projectile
{
    private bool _isPlayerShoot;
    private int _damage;
    
    public Bullet(bool isPlayerShoot, int damage, int speed, int x, int y)
    {
        _isPlayerShoot = isPlayerShoot;
        _damage = damage;
        _speed = speed;
        InitializeComponent();

        Size = new Size(4, 12);
        Location = new Point(x, y);
        Visible = true;

        if (_isPlayerShoot)
        {
            _speed = -_speed; // Пули игрока летят вверх (отрицательная скорость)
            _brush = new SolidBrush(Color.Yellow);
        }
        else
        {
            _brush = new SolidBrush(Color.Red);
        }
    }

    protected override void IntersectsWith(Entity entity)
    {
        // Пули наносят урон только врагам
        if (_isPlayerShoot == entity is Enemy)
        {
            entity.TakeDamage(_damage);
        }
    }
}