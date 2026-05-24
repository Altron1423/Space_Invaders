using System.ComponentModel;

namespace Space_Invaders;

public enum PowerupType
{
    SpeedUp,
    DoubleShot,
    Shield,
    ExtraLife
}

public partial class Powerup : Projectile
{
    private PowerupType _bonus;
    private float _duration;
    private Label _iconLabel;

    public Powerup()
    {
        InitializeComponent();
    }

    public Powerup(PowerupType bonus, int speed, int x, int y)
    {
        _bonus = bonus;
        _speed = speed;
        _duration = DurationBonus(bonus);

        InitializeComponent();

        // Настройка внешнего вида бонуса
        this.Size = new Size(50, 50);
        this.Location = new Point(x, y);
        this.Visible = true;

        // Создаем Label для отображения иконки
        _iconLabel = new Label();
        _iconLabel.Size = this.Size;
        _iconLabel.Location = new Point(0, 0);
        _iconLabel.TextAlign = ContentAlignment.MiddleCenter;
        _iconLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        _iconLabel.BackColor = Color.Transparent;

        SetPowerupAppearance();

        this.Controls.Add(_iconLabel);

        // Добавляем обработчик события Paint для фона
        this.Paint += (s, e) =>
        {
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(brush, 0, 0, this.Width, this.Height);
            }
        };
    }

    private void SetPowerupAppearance()
    {
        switch (_bonus)
        {
            case PowerupType.SpeedUp:
                this.BackColor = Color.Black;
                _iconLabel.Text = "⚡";
                _iconLabel.ForeColor = Color.DarkBlue;
                break;
            case PowerupType.DoubleShot:
                this.BackColor = Color.Black;
                _iconLabel.Text = "✧";
                _iconLabel.ForeColor = Color.DarkOrange;
                break;
            case PowerupType.Shield:
                this.BackColor = Color.Black;
                _iconLabel.Text = "🛡️";
                _iconLabel.ForeColor = Color.DarkGreen;
                break;
            case PowerupType.ExtraLife:
                this.BackColor = Color.Black;
                _iconLabel.Text = "❤️";
                _iconLabel.ForeColor = Color.Red;
                break;
        }
    }

    private float DurationBonus(PowerupType bonus) //вид бонусов
    {
        switch (bonus)
        {
            case PowerupType.SpeedUp:
                return 5.0f;
            case PowerupType.DoubleShot:
                return 5.0f;
            case PowerupType.Shield:
                return 3.0f;
            case PowerupType.ExtraLife:
                return 0.0f;
            default:
                return 0.0f;
        }
    }

    protected override void IntersectsWith(Entity player) //столкновение с игроком
    {
        if (player is Player)
        {
            Effect((Player)player);
        }
    }

    private void Effect(Player player)
    {
        switch (_bonus)
        {
            case PowerupType.SpeedUp:
                player.ActivateSpeedBoost(_duration);
                break;
            case PowerupType.DoubleShot:
                player.ActivateDoubleShot(_duration);
                break;
            case PowerupType.Shield:
                player.ActivateShield(_duration);
                break;
            case PowerupType.ExtraLife:
                player.AddExtraLife();
                break;
        }
    }
}