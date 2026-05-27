using Space_Invaders.forms;
using System.ComponentModel;
using System.Drawing.Text;

namespace Space_Invaders;

public partial class Form1 : Form
{
    private bool _paused = true;
    private Enemy[] enemies;
    private Powerup[] powerups;
    private List<Bullet> bullets;
    private System.Windows.Forms.Timer _powerupSpawnTimer;
    private Random _random = new Random();

    public Form1()
    {
        InitializeComponent();
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.Manual;

        right_fon.FlatAppearance.MouseOverBackColor = right_fon.BackColor;
        left_fon.FlatAppearance.MouseOverBackColor = left_fon.BackColor;

        bullets = new List<Bullet>();

        _powerupSpawnTimer = new System.Windows.Forms.Timer();
        _powerupSpawnTimer.Interval = 3000;
        _powerupSpawnTimer.Tick += SpawnRandomPowerup;
    }

    public bool IsPaused => _paused;

    private void Form1_Load(object sender, EventArgs e)
    {
        player.SetParentForm(this);
        player.Focus();
        KeyPreview = true;
        player.TabStop = true;
    }

    private void RunGame(object sender, EventArgs e)
    {
        enemies = new Enemy[30];
        powerups = new Powerup[10];
        bullets.Clear();

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
        progressBar1.Visible = true;
        progressBar2.Visible = true;
        progressBar3.Visible = true;

        // Инициализация индикаторов
        UpdateHealthDisplay(3);
        ResetPowerupIndicators();

        timer1.Start();
        _powerupSpawnTimer.Start();
    }

    private void SpawnRandomPowerup(object sender, EventArgs e)
    {
        if (_paused) return;

        int randomX = _random.Next(left_fon.Width + 20, right_fon.Left - 50);
        int randomY = 20;
        PowerupType randomBonus = (PowerupType)_random.Next(4);
        int randomSpeed = _random.Next(3, 8);

        Powerup powerup = new Powerup(randomBonus, randomSpeed, randomX, randomY);
        AddPowerup(powerup);
    }

    private void SpawnPowerupAtPosition(int x, int y)
    {
        PowerupType randomBonus = (PowerupType)_random.Next(4);
        int randomSpeed = _random.Next(3, 8);
        Powerup powerup = new Powerup(randomBonus, randomSpeed, x, y);
        AddPowerup(powerup);
    }

    public void AddBullet(Bullet bullet)
    {
        bullet.SetParentForm(this);
        bullets.Add(bullet);
        Controls.Add(bullet);
        bullet.BringToFront();
    }

    public void RemoveProjectile(Projectile projectile)
    {
        if (projectile is Bullet bullet)
        {
            bullets.Remove(bullet);
            Controls.Remove(bullet);
        }
        else if (projectile is Powerup powerup)
        {
            if (powerups != null)
            {
                for (int i = 0; i < powerups.Length; i++)
                {
                    if (powerups[i] == powerup)
                    {
                        powerups[i] = null;
                        break;
                    }
                }
            }
            Controls.Remove(powerup);
        }
        projectile.Dispose();
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
        }

        if (progressBar2 != null)
        {
            progressBar2.Maximum = 100;
            progressBar2.Value = 0;
        }

        if (progressBar3 != null)
        {
            progressBar3.Maximum = 100;
            progressBar3.Value = 0;
        }
    }

    public void UpdatePowerupIndicators()
    {
        if (player == null) return;

        // Обновляем индикатор скорости (progressBar1)
        if (progressBar1 != null)
        {
            if (player.HasSpeedBoost())
            {
                float remaining = player.GetSpeedBoostRemaining();
                float maxDuration = 5.0f;
                int value = (int)((remaining / maxDuration) * 100);
                progressBar1.Value = Math.Max(0, Math.Min(100, value));
                progressBar1.ForeColor = Color.Blue;
                progressBar1.Style = ProgressBarStyle.Continuous;
            }
            else
            {
                progressBar1.Value = 0;
                progressBar1.ForeColor = Color.Blue;
            }
        }

        // Обновляем индикатор двойного выстрела (progressBar2)
        if (progressBar2 != null)
        {
            if (player.HasDoubleShot())
            {
                float remaining = player.GetDoubleShotRemaining();
                float maxDuration = 5.0f;
                int value = (int)((remaining / maxDuration) * 100);
                progressBar2.Value = Math.Max(0, Math.Min(100, value));
                progressBar2.ForeColor = Color.Yellow;
            }
            else
            {
                progressBar2.Value = 0;
                progressBar2.ForeColor = Color.Orange;
            }
        }

        // Обновляем индикатор щита (progressBar3)
        if (progressBar3 != null)
        {
            if (player.HasShield())
            {
                float remaining = player.GetShieldRemaining();
                float maxDuration = 5.0f;
                int value = (int)((remaining / maxDuration) * 100);
                progressBar3.Value = Math.Max(0, Math.Min(100, value));
                progressBar3.ForeColor = Color.Yellow;
            }
            else
            {
                progressBar3.Value = 0;
                progressBar3.ForeColor = Color.Cyan;
            }
        }
    }

    public void GameOver()
    {
        _powerupSpawnTimer.Stop();
        timer1.Stop();
        _paused = true;
        MessageBox.Show("Игра окончена!", "Space Invaders", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

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

        if (!_paused)
        {
            player.PlayerKeyDown(e);
        }
    }

    private void player_KeyUp(object sender, KeyEventArgs e)
    {
        if (!_paused)
        {
            player.PlayerKeyUp(e);
        }
    }

    private void button_MouseMove(object sender, MouseEventArgs e)
    {
        Button bt = sender as Button;
        if (!(bt == pause_button && _paused))
        {
            bt.BackColor = Color.DarkGreen;
        }
        bt.ForeColor = Color.Black;
    }

    private void button_MouseLeave(object sender, EventArgs e)
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

    private void BringButtonsToFront()
    {
        continue_button.BringToFront();
        exit_button.BringToFront();
        button1.BringToFront();
        pause_button.BringToFront();
    }

    private void SendPowerupsToBack()
    {
        if (powerups != null)
        {
            foreach (var powerup in powerups)
            {
                if (powerup != null && powerup.Visible)
                {
                    powerup.SendToBack();
                }
            }
        }
        foreach (var bullet in bullets)
        {
            if (bullet != null && bullet.Visible)
            {
                bullet.SendToBack();
            }
        }
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

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (_paused) return;

        player.Update();

        player.Top = this.ClientSize.Height - player.Height - 2;
        UpdatePowerupIndicators();

        if (enemies != null)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy != null && enemy.Visible)
                    enemy.Update();
            }
        }

        if (powerups != null)
        {
            for (int i = 0; i < powerups.Length; i++)
            {
                if (powerups[i] != null && powerups[i].Visible)
                {
                    powerups[i].Update(new Entity[] { player });
                }
            }
        }

        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            if (bullets[i] != null && bullets[i].Visible)
            {
                bullets[i].Update(enemies);
            }
        }

        Invalidate();
    }

    public void AddPowerup(Powerup powerup)
    {
        powerup.SetParentForm(this);

        if (powerups != null)
        {
            for (int i = 0; i < powerups.Length; i++)
            {
                if (powerups[i] == null)
                {
                    powerups[i] = powerup;
                    break;
                }
            }
        }

        Controls.Add(powerup);
        powerup.BringToFront();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        if (enemies != null)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] == enemy)
                {
                    enemies[i] = null;
                    break;
                }
            }
        }
        Controls.Remove(enemy);
        enemy.Dispose();
    }

    public void RemovePowerup(Powerup powerup)
    {
        if (powerups != null)
        {
            for (int i = 0; i < powerups.Length; i++)
            {
                if (powerups[i] == powerup)
                {
                    powerups[i] = null;
                    break;
                }
            }
        }
        Controls.Remove(powerup);
        powerup.Dispose();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Form3 form3 = new Form3();
        form3.StartPosition = FormStartPosition.Manual;
        form3.Location = new Point(
            Location.X + (Width - form3.Width) / 2,
            Location.Y + (Height - form3.Height) / 2
        );
        Hide();
        form3.ShowDialog();
        Close();
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
        bt.ForeColor = Color.Black;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Form5 form5 = new Form5();
        form5.StartPosition = FormStartPosition.Manual;
        form5.Location = new Point(
            Location.X + (Width - form5.Width) / 2,
            Location.Y + (Height - form5.Height) / 2
        );
        Hide();
        form5.ShowDialog();
        Close();
    }
}