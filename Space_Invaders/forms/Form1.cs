using Space_Invaders.forms;
using System.ComponentModel;
using System.Drawing.Text;
using System.Runtime.InteropServices.Swift;
using Timer = System.Timers.Timer;

namespace Space_Invaders;

public partial class Form1 : BaseForm
{
    private bool _paused = true;
    private List<Entity> _enemies;
    private List<Powerup> _powerups;
    private List<Bullet> _bullets;
    private int _score = 0;
    private int _dificlty;
    private int _level = 1;

    private int _tick = 0;
    private System.Windows.Forms.Timer _powerupSpawnTimer;
    private Random _random = new Random();
    private int _lineCount = 4;

    public Form1()
    {
        InitializeComponent();
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.Manual;

        right_fon.FlatAppearance.MouseOverBackColor = right_fon.BackColor;
        left_fon.FlatAppearance.MouseOverBackColor = left_fon.BackColor;

        _powerupSpawnTimer = new System.Windows.Forms.Timer();
        _powerupSpawnTimer.Interval = 3000;
        _powerupSpawnTimer.Tick += SpawnRandomPowerup;
    }

    public Form1(int dificlty): this()
    {
        _dificlty = dificlty;
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        player.SetParentForm(this);
        player.Focus();
        KeyPreview = true;
        player.TabStop = true;

        // Для PictureBox или Panel нужно установить:
        player.TabStop = true; // Разрешить получение фокуса
        _enemies = new List<Entity>();
        _powerups = new List<Powerup>();
        _bullets = new List<Bullet>();
    }

    private void log(object text)
    {
        Console.WriteLine($"{_tick}: {text}");
    }

    private void RunGame(object sender, EventArgs e)
    {
        player.SetBorder(left_fon.Width, right_fon.Left);
        player.Location = new Point((left_fon.Width + right_fon.Left) / 2 - player.Width / 2,
                                     ClientSize.Height - 100);
        player.Visible = true;

        _paused = false;

        start_button.Visible = false;
        right_fon.Visible = true;
        left_fon.Visible = true;
        pause_button.Visible = true;

        left_fon.Enabled = false;
        right_fon.Enabled = false;
        label1.Visible = true;
        label2.Visible = true;
        label3.Visible = true;
        label4.Visible = true;
        label5.Visible = true;
        label6.Visible = true;
        progressBar1.Visible = true;
        progressBar2.Visible = true;
        progressBar3.Visible = true;

        // Инициализация индикаторов
        UpdateHealthDisplay(3);
        ResetPowerupIndicators();

        timer1.Start();
        _powerupSpawnTimer.Start();

        SummonStartEnemy();
    }

    private void SummonStartEnemy()
    {
        int count = 10 + (int)(4 * _level * (0.5 + 0.2 * _dificlty));
        
        for (int i = 0; i < count; i++)
        {
            int x = 275 + i % _lineCount * 70 + i / _lineCount % 2 * 35;
            int y =  40 + i / _lineCount * 50;
            summon_enemy(x, y);
        }
    }

    private void SpawnRandomPowerup(object sender, EventArgs e)
    {
        if (_paused) return;
        Console.WriteLine("Spawning random powerup");

        int randomX = _random.Next(left_fon.Width + 20, right_fon.Left - 50);
        int randomY = 20;

        SpawnPowerupAtPosition(randomX, randomY);
    }

    public void UpdateHealthDisplay(int health)
    {
        if (label1 != null)
        {
            string hearts = "";
            for (int i = 0; i < health; i++)
            {
                hearts += "❤️ ";
            }
            label1.Text = hearts.Trim();

            if (health <= 0)
            {
                label1.Text = "💀";
            }
        }
    }

    private void ResetPowerupIndicators()
    {
        if (progressBar1 != null)
        {
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.BackColor = Color.FromArgb(255, 64, 64, 64); 
        }

        if (progressBar2 != null)
        {
            progressBar2.Maximum = 100;
            progressBar2.Value = 0;
            progressBar2.BackColor = Color.FromArgb(255, 64, 64, 64);
        }

        if (progressBar3 != null)
        {
            progressBar3.Maximum = 100;
            progressBar3.Value = 0;
            progressBar3.BackColor = Color.FromArgb(255, 64, 64, 64);
        }
    }

    public void UpdatePowerupIndicators()
    {
        if (player == null) return;

        // Обновляем индикатор скорости (progressBar1 - синий при активации)
        if (progressBar1 != null)
        {
            if (player.HasSpeedBoost())
            {
                float remaining = player.GetSpeedBoostRemaining();
                float maxDuration = 5.0f;
                int value = (int)((remaining / maxDuration) * 100);
                progressBar1.Value = Math.Max(0, Math.Min(100, value));
                progressBar1.ProgressColor = Color.Blue;
            }
            else
            {
                progressBar1.Value = 0;
                progressBar1.ProgressColor = Color.Gray;
            }
            progressBar1.Invalidate();
        }

        // Обновляем индикатор двойного выстрела (progressBar2 - оранжевый при активации)
        if (progressBar2 != null)
        {
            if (player.HasDoubleShot())
            {
                float remaining = player.GetDoubleShotRemaining();
                float maxDuration = 5.0f;
                int value = (int)((remaining / maxDuration) * 100);
                progressBar2.Value = Math.Max(0, Math.Min(100, value));
                progressBar2.ProgressColor = Color.Orange;
            }
            else
            {
                progressBar2.Value = 0;
                progressBar2.ProgressColor = Color.Gray;
            }
            progressBar2.Invalidate();
        }

        // Обновляем индикатор щита (progressBar3 - зелёный при активации)
        if (progressBar3 != null)
        {
            if (player.HasShield())
            {
                float remaining = player.GetShieldRemaining();
                float maxDuration = 5.0f;
                int value = (int)((remaining / maxDuration) * 100);
                progressBar3.Value = Math.Max(0, Math.Min(100, value));
                progressBar3.ProgressColor = Color.Green;
            }
            else
            {
                progressBar3.Value = 0;
                progressBar3.ProgressColor = Color.Gray;
            }
            progressBar3.Invalidate();
        }
    }
    
    public void GameOver()
    {
        _powerupSpawnTimer.Stop();
        timer1.Stop();
        _paused = true;
        MessageBox.Show("Игра окончена!", "Space Invaders", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BringButtonsToFront()
    {
        continue_button.BringToFront();
        exit_button.BringToFront();
        button1.BringToFront();
        pause_button.BringToFront();
    }

    private void SendPowerupsToBack()
    {
        if (_powerups != null)
        {
            foreach (var powerup in _powerups)
            {
                if (powerup != null && powerup.Visible)
                {
                    powerup.SendToBack();
                }
            }
        }
        foreach (var bullet in _bullets)
        {
            if (bullet != null && bullet.Visible)
            {
                bullet.SendToBack();
            }
        }
    }


    private void timer1_Tick(object sender, EventArgs e)
    {
        _tick++;

        if (_paused) return;
        player.Update();
        Shoot(player);

        UpdatePowerupIndicators();


        List<Enemy> enemies = new List<Enemy>();
        List<Powerup> powerups = new List<Powerup>();
        List<Bullet> bullets = new List<Bullet>();
        foreach (Enemy enemy in _enemies)
        {
            enemy.Update();
            Shoot(enemy);
            if (enemy.Health <= 0)
            {
                enemies.Add(enemy);
                _score += enemy.points;
                label5.Text = $"🎯 СЧЁТ: {_score}";
            }
            else if (enemy.Top >= Height * 0.8)
            {
                enemies.Add(enemy);
                player.TakeDamage(1);
            }
        }
        RemoveEnemy(enemies);
        if (_enemies.Count == 0)
        {
            _level++;
            SummonStartEnemy();
            foreach (Bullet bullet in _bullets)
            {
                bullets.Add(bullet);
            }

            foreach (Powerup powerup in _powerups)
            {
                powerups.Add(powerup);
            }
            RemoveBullet(bullets);
            RemovePowerup(powerups);
            return;
        }


        foreach (Powerup powerup in _powerups)
        {
            powerup.Update();
            powerup.TestInteractWith(player);
            if (powerup.Delete)
            {
                powerups.Add(powerup);
            }
            ;
        }
        RemovePowerup(powerups);


        foreach (Bullet bullet in _bullets)
        {
            bullet.Update();
            bullet.TestInteractWith(player);
            bullet.TestInteractWith(_enemies);
            if (bullet.Delete)
            {
                bullets.Add(bullet);
            }
        }
        RemoveBullet(bullets);
    }




    //        //        \\
    //       || buttons ||
    //       \\        //
    
    private void player_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            if (pause_button.Visible && pause_button.Enabled)
            {
                PauseClick(pause_button, EventArgs.Empty);
            }
            return;
        }

        player.PlayerKeyDown(e);
        if (e.KeyCode == Keys.R)
        {
            // Console.WriteLine(_enemies);
            summon_enemy(275 + _enemies.Count * 30, 40 + _enemies.Count % 3 * 10);
        }
    }

    private void player_KeyUp(object sender, KeyEventArgs e)
    {
        player.PlayerKeyUp(e);
    }

    protected override void button_MouseMove(object sender, MouseEventArgs e)
    {
        Button bt = sender as Button;
        if (!(bt == pause_button && _paused))
        {
            bt.BackColor = Color.DarkGreen;
        }
        bt.ForeColor = Color.Black;
    }

    protected override void button_MouseLeave(object sender, EventArgs e)
    {
        Button bt = sender as Button;
        if (!(bt == pause_button && _paused))
        {
            bt.BackColor = Color.FromArgb(255, 0, 64, 0);
        }
        bt.ForeColor = Color.White;
    }

    private void PauseClick(object sender, EventArgs e)
    {
        if (_paused)
        {
            timer1.Enabled = true;
            _powerupSpawnTimer.Enabled = true;
            player.ResumePowerupTimers();
            continue_button.Visible = false;
            exit_button.Visible = false;
            button1.Visible = false;  // Добавьте эту строку
            button2.Visible = false;  // Добавьте эту строку
            pause_button.BackColor = Color.FromArgb(255, 0, 64, 0);

            SendPowerupsToBack();
        }
        else
        {
            pause_button.BackColor = Color.Maroon;
            timer1.Enabled = false;
            _powerupSpawnTimer.Enabled = false;
            player.PausePowerupTimers();
            continue_button.Visible = true;
            exit_button.Visible = true;
            button1.Visible = true;
            button2.Visible = true;

            // Поднимаем кнопки на передний план
            BringButtonsToFront();

            // Отправляем бонусы на задний план
            SendPowerupsToBack();
        }
        _paused = !_paused;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Form3 form3 = new Form3(this); // Передаём ссылку на текущую форму
        form3.StartPosition = FormStartPosition.Manual;
        form3.Location = new Point(
            Location.X + (Width - form3.Width) / 2,
            Location.Y + (Height - form3.Height) / 2
        );
        Hide();
        form3.ShowDialog();
        //Form3 form3 = new Form3();
        //form3.StartPosition = FormStartPosition.Manual;
        //form3.Location = new Point(
        //    Location.X + (Width - form3.Width) / 2,
        //    Location.Y + (Height - form3.Height) / 2
        //);
        //Hide();
        //form3.ShowDialog();
        //Close();
    }

    private void exit_button_MouseLeave(object sender, EventArgs e)
    {
        Button bt = sender as Button;
        bt.BackColor = Color.Maroon;
        bt.ForeColor = Color.White;
    }

    private void exit_button_MouseMove(object sender, MouseEventArgs e)
    {
        Button bt = sender as Button;
        bt.BackColor = Color.Firebrick;
        bt.ForeColor = Color.FromArgb(255, 64, 64, 64); 
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Form5 form5 = new Form5(this); // Передаём ссылку на текущую форму
        form5.StartPosition = FormStartPosition.Manual;
        form5.Location = new Point(
            Location.X + (Width - form5.Width) / 2,
            Location.Y + (Height - form5.Height) / 2
        );
        Hide();
        form5.ShowDialog();
        //Form5 form5 = new Form5();
        //form5.StartPosition = FormStartPosition.Manual;
        //form5.Location = new Point(
        //    Location.X + (Width - form5.Width) / 2,
        //    Location.Y + (Height - form5.Height) / 2
        //);
        //Hide();
        //form5.ShowDialog();
        //Close();
    }

    private void ContinueClick(object sender, EventArgs e)
    {
        timer1.Enabled = true;
        _powerupSpawnTimer.Enabled = true;
        player.ResumePowerupTimers();
        continue_button.Visible = false;
        exit_button.Visible = false;
        _paused = false;
        button1.Visible = false;
        button2.Visible = false;

        SendPowerupsToBack();
    }

    private void ButtonExit(object sender, EventArgs e)
    {
        var otvet = MessageBox.Show("Вы уверены, что хотите завершить?", "Space Invaders", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (otvet == DialogResult.Yes)
        {
            Form2 form2 = new Form2();
            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = new Point(
                Location.X + (Width - form2.Width) / 2,
                Location.Y + (Height - form2.Height) / 2
            );
            Hide();
            form2.ShowDialog();
            Close();
        }
    }

    public bool IsPaused => _paused;
}
