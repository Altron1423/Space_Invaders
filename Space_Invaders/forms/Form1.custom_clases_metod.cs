namespace Space_Invaders;

public partial class Form1
{

    public void AddBullet(Bullet bullet)
    {
        bullet.SetParentForm(this);
        _bullets.Add(bullet);
        Controls.Add(bullet);
        bullet.BringToFront();
    }
    
    public void RemoveBullet(List<Bullet> bullets)
    {
        foreach (Bullet bullet in bullets)
        {
            _bullets.Remove(bullet);
            Controls.Remove(bullet);
        }
    }
    
    public void AddPowerup(PowerupType randomBonus, int randomSpeed, int x, int y)
    {
        Powerup powerup = new Powerup(randomBonus, randomSpeed, x, y);
        powerup.SetParentForm(this);
        _powerups.Add(powerup);
    }

    public void RemovePowerup(List<Powerup> powerups)
    {
        foreach (Powerup powerup in powerups)
        {
            _powerups.Remove(powerup);
            Controls.Remove(powerup);
        }
    }
    
    
    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
        Controls.Add(enemy);
    }

    public void RemoveEnemy(List<Enemy> enemies)
    {
        foreach (Enemy enemy in enemies)
        {
            _enemies.Remove(enemy);
            Controls.Remove(enemy);
        }
    }
    
    
    private void Shoot(Entity entity)
    {
        // Console.WriteLine(entity.GetType());
        // Console.WriteLine(entity.GetType() == player.GetType());
        bool isPlayerShoot = entity.GetType() == player.GetType();
        int damage = 1, speed = 10;
        if (isPlayerShoot)
        {
            damage = 1;
        }
        Bullet bullet = new(
            isPlayerShoot, damage, speed,
            entity.Location.X + player.Width / 2, entity.Location.Y - 30
            );
        AddBullet(bullet);
    }
    
    private void SpawnPowerupAtPosition(int x, int y)
    {
        PowerupType randomBonus = (PowerupType)_random.Next(4);
        int randomSpeed = _random.Next(3, 8);
        AddPowerup(randomBonus, randomSpeed, x, y);
    }

    private void summon_enemy(int x, int y)
    {
        Enemy enemy = new Enemy();
        enemy.Location = new Point(x, y);
        enemy.Size = new Size(40, 40);
        
    }
    
}