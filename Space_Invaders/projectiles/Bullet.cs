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

        this.BackColor = Color.Yellow;
        this.Size = new Size(4, 12);
        this.Location = new Point(x, y);
        this.Visible = true;

        if (_isPlayerShoot)
        {
            _speed = -_speed; // Пули игрока летят вверх (отрицательная скорость)
            this.BackColor = Color.Yellow;
        }
        else
        {
            _speed = Math.Abs(_speed); // Пули врагов летят вниз (положительная скорость)
            this.BackColor = Color.Red;
        }
    }

    protected override void IntersectsWith(Entity entity)
    {
        // Пули наносят урон только врагам
        if (_isPlayerShoot && entity is Enemy)
        {
            entity.TakeDamage(_damage);
        }
    }
}