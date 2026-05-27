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

        BackColor = Color.Yellow;
        Size = new Size(4, 12);
        Location = new Point(x, y);
        Visible = true;

        if (_isPlayerShoot)
        {
            _speed = -_speed; // ���� ������ ����� ����� (������������� ��������)
            this.BackColor = Color.Yellow;
        }
        else
        {
            _speed = Math.Abs(_speed); // ���� ������ ����� ���� (������������� ��������)
            this.BackColor = Color.Red;
        }
    }

    protected override void IntersectsWith(Entity entity)
    {
        // ���� ������� ���� ������ ������
        if (_isPlayerShoot && entity is Enemy)
        {
            entity.TakeDamage(_damage);
        }
    }
}