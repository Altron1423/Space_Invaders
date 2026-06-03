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
        Controls.Add(powerup);
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
        if (isPlayerShoot)
        {
            int damage = 1, speed = 10;
            PlayerShotEnum shot = player.Shot;
            if (shot != PlayerShotEnum.None)
                Console.WriteLine(shot);
            if (shot == PlayerShotEnum.OneShot)
            {
                int bulletX = player.Left + player.Width / 2 - 2;
                int bulletY = player.Top - 10;
                Bullet bullet = new Bullet(true, damage, speed, bulletX, bulletY);
                AddBullet(bullet);
            }
            else if (shot == PlayerShotEnum.TwoShot) {
                int bulletX1 = player.Left + player.Width / 2 - 12;
                int bulletX2 = player.Left + player.Width / 2 + 8;
                int bulletY = player.Top - 10;

                Bullet bullet1 = new Bullet(true, damage, speed, bulletX1, bulletY);
                Bullet bullet2 = new Bullet(true, damage, speed, bulletX2, bulletY);
                AddBullet(bullet1);
                AddBullet(bullet2);
            }
        }
    }
    
    private void SpawnPowerupAtPosition(int x, int y)
    {
        PowerupType randomBonus = (PowerupType)_random.Next(4);
        int randomSpeed = _random.Next(3, 8);
        AddPowerup(randomBonus, randomSpeed, x, y);
    }

    private void summon_enemy(int x, int y)
    {
        int typeIndex = _random.Next(1,100);
        EnemyType type;
        if (typeIndex > 80)
        {
            type = EnemyType.Fast;
        }
        else if (typeIndex > 60)
        {
            type = EnemyType.Armored;
        }
        else
        {
            type = EnemyType.Normal;
        }
        
        Console.WriteLine(type);
        summon_enemy(x, y, type);
    }

    private void summon_enemy(int x, int y, EnemyType type)
    {
        Enemy enemy = new Enemy(type);
        enemy.Location = new Point(x, y);
        enemy.Size = new Size(40, 40);
        enemy.SetBorder(left_fon.Width, right_fon.Left);
        
        AddEnemy(enemy);
    }
    
}