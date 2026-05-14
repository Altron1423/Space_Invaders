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
    }
    protected override void IntersectsWith(Entity entity)
    {
        entity.TakeDamage(_damage);
    }
}