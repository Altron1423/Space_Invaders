using Space_Invaders.forms;

namespace Space_Invaders;

public partial class GameForm : BaseForm
{
    private bool _paused = true;
    private List<Entity> _enemies;
    private List<Powerup> _powerups;
    private List<Bullet> _bullets;
    private int _score = 0;
    private int _difficulty;
    private int _startDifficulty;
    private int _level = 1;

    private System.Windows.Forms.Timer _powerupSpawnTimer;
    private Random _random = new Random();
    private int _lineCount = 4;

    public GameForm()
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

    public GameForm(int difficulty) : this()
    {
        _difficulty = difficulty;
        _startDifficulty = _difficulty;
        SetDifficultyLabel();
    }

    private void SetDifficultyLabel()
    {
        if (_difficulty == 1)
        {
            labelDificalty.Text = "СЛОЖНОТЬ: ЛЕГКО";
            labelDificalty.ForeColor = Color.FromArgb(255, 0, 255, 0);
        } else if (_difficulty == 2)
        {
            labelDificalty.Text = "СЛОЖНОТЬ: СРЕДНЕ";
            labelDificalty.ForeColor = Color.FromArgb(255, 255, 255, 0);
        } else if (_difficulty == 3)
        {
            labelDificalty.Text = "СЛОЖНОТЬ: СЛОЖНО";
            labelDificalty.ForeColor = Color.FromArgb(255, 255, 0, 0);
        } else if (_difficulty >= 4)
        {
            if (_difficulty > 4)
                labelDificalty.Text = $"СЛОЖНОТЬ: КОШМАР {_difficulty-3}";
            else
                labelDificalty.Text = "СЛОЖНОТЬ: КОШМАР";
            labelDificalty.ForeColor = Color.FromArgb(255, 0, 0, 0);
        }
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
        labelLevel.Visible = true;
        labelDificalty.Visible = true;
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
        int count = 15 + (int)(7 * _level * (0.5 + 0.3 * _difficulty));
        int fixLine = count / _lineCount * 50;
        for (int i = 0; i < count; i++)
        {
            int x = 275 + i % _lineCount * 70 + i / _lineCount % 2 * 35;
            int y =  60 + i / _lineCount * 50 - fixLine;
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

        GameOverForm gameOverForm = new GameOverForm(_startDifficulty);
        gameOverForm.StartPosition = FormStartPosition.Manual;
        gameOverForm.Location = new Point(
            Location.X + (Width - gameOverForm.Width) / 2,
            Location.Y + (Height - gameOverForm.Height) / 2
        );

        Hide();
        gameOverForm.ShowDialog();
        Close();
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
            if (_level == 5)
            {
                _level = 1;
                if (_difficulty != 3){}
                else if (_startDifficulty != 1)
                {
                    GameOver();
                    return;
                }
                _difficulty++;
                SetDifficultyLabel();
            }
            _level++;
            labelLevel.Text = $"УРОВЕНЬ: {_level}";
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
        ControleForm controleForm = new ControleForm(); // Передаём ссылку на текущую форму
        controleForm.StartPosition = FormStartPosition.Manual;
        controleForm.Location = new Point(
            Location.X + (Width - controleForm.Width) / 2,
            Location.Y + (Height - controleForm.Height) / 2
        );
        Hide();
        controleForm.ShowDialog();
        Show();
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
        InfoForm infoForm = new InfoForm(); // Передаём ссылку на текущую форму
        infoForm.StartPosition = FormStartPosition.Manual;
        infoForm.Location = new Point(
            Location.X + (Width - infoForm.Width) / 2,
            Location.Y + (Height - infoForm.Height) / 2
        );
        Hide();
        infoForm.ShowDialog();
        Show();
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
        MainMenuForm mainMenuForm = new MainMenuForm();
        mainMenuForm.StartPosition = FormStartPosition.Manual;
        mainMenuForm.Location = new Point(
            Location.X + (Width - mainMenuForm.Width) / 2,
            Location.Y + (Height - mainMenuForm.Height) / 2
        );
        Hide();
        mainMenuForm.ShowDialog();
        Close();
    }
}
