using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;


namespace Space_Invaders;

public partial class Player : Entity
{
    const int FIRE_TYPE = 2;
    
    private bool _keyAPress, _keyDPress;
    private readonly Stopwatch _cooldownTimer = new ();
    private TimeSpan _cooldownDuration;
    
    private Form1 _parentForm;

    // Переменные для бонусов
    private bool _hasShield = false;
    private bool _doubleShotActive = false;
    private bool _speedBoostActive = false;
    private System.Windows.Forms.Timer _speedBoostTimer;
    private System.Windows.Forms.Timer _doubleShotTimer;
    private System.Windows.Forms.Timer _shieldTimer;
    private int _originalSpeed;

    // Текущее время действия бонусов (в секундах)
    private float _speedBoostRemaining = 0;
    private float _doubleShotRemaining = 0;
    private float _shieldRemaining = 0;
    
    public Player()
    {
        InitializeComponent();
        InitializePowerupTimers();
    }

    public Player(IContainer container)
    {
        container.Add(this);
        InitializeComponent();
        InitializePowerupTimers();
    }

    private void InitializePowerupTimers()
    {
        _speedBoostTimer = new System.Windows.Forms.Timer();
        _speedBoostTimer.Interval = 300; //обнавляем каждые 300мс
        _speedBoostTimer.Tick += (s, e) => UpdateSpeedBoost();

        _doubleShotTimer = new System.Windows.Forms.Timer();
        _doubleShotTimer.Interval = 100;
        _doubleShotTimer.Tick += (s, e) => UpdateDoubleShot();

        _shieldTimer = new System.Windows.Forms.Timer();
        _shieldTimer.Interval = 100;
        _shieldTimer.Tick += (s, e) => UpdateShield();
    }

    public void SetParentForm(Form1 form)
    {
        _parentForm = form;
    }

    protected override void Init()
    {
        _health = 3;
        _originalSpeed = 10;
        _speed = _originalSpeed;
        _moveOrientation = 0;
        _keyAPress = false;
        _keyDPress = false;
        _cooldownDuration = TimeSpan.FromSeconds(0.5);
        _cooldownTimer.Start();
        _brush = Brushes.Green;
        this.DoubleBuffered = true; // Включаем двойную буферизацию
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        // Рисуем игрока с текущим цветом в зависимости от щита
        using (SolidBrush brush = new SolidBrush(_hasShield ? Color.Cyan : Color.Green))
        {
            e.Graphics.FillRectangle(brush, 0, 0, Width - 1, Height - 1);
        }
    }

    public int GetHealth() => _health;
    public bool HasShield() => _hasShield;
    public bool HasDoubleShot() => _doubleShotActive;
    public bool HasSpeedBoost() => _speedBoostActive;

    public float GetSpeedBoostRemaining() => _speedBoostRemaining;
    public float GetDoubleShotRemaining() => _doubleShotRemaining;
    public float GetShieldRemaining() => _shieldRemaining;

    
    public PlayerShotEnum Shot
    {
        get
        {
            bool sh = _shoot;
            if (FIRE_TYPE == 1)
                _shoot = false;
            if (_cooldownTimer.Elapsed >= _cooldownDuration)
            {
                _cooldownTimer.Restart();
                PlayerShotEnum value = PlayerShotEnum.None;
                if (!sh) {}
                else if (_doubleShotActive)
                    return PlayerShotEnum.TwoShot;
                else
                    return PlayerShotEnum.OneShot;
            }
            return PlayerShotEnum.None;
            
        }
    }


    // Методы для паузы таймеров бонусов
    public void PausePowerupTimers()
    {
        if (_speedBoostTimer.Enabled)
            _speedBoostTimer.Stop();
        if (_doubleShotTimer.Enabled)
            _doubleShotTimer.Stop();
        if (_shieldTimer.Enabled)
            _shieldTimer.Stop();
    }

    public void ResumePowerupTimers()
    {
        if (_speedBoostActive && !_speedBoostTimer.Enabled)
            _speedBoostTimer.Start();
        if (_doubleShotActive && !_doubleShotTimer.Enabled)
            _doubleShotTimer.Start();
        if (_hasShield && !_shieldTimer.Enabled)
            _shieldTimer.Start();
    }

    public void PlayerKeyUp(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.A)
        {
            _moveOrientation++;
            _keyAPress = false;
        }
        else if (e.KeyCode == Keys.D)
        {
            _moveOrientation--;
            _keyDPress = false;
        }
        else if (e.KeyCode == Keys.Space && FIRE_TYPE == 2)
            _shoot = false;
    }

    public void PlayerKeyDown(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.A && !_keyAPress)
        {
            _keyAPress = true;
            _moveOrientation--;
        }
        else if (e.KeyCode == Keys.D && !_keyDPress)
        {
            _keyDPress = true;
            _moveOrientation++;
        }
        else if (e.KeyCode == Keys.Space)
            _shoot = true;
    }
    
    public override void TakeDamage(int amount)
    {
        if (_hasShield)
        {
            return;         // щит поглощает урон
        }

        _health -= amount;
        if (_health <= 0)
            Die();
        _parentForm?.UpdateHealthDisplay(_health);
    }

    public override void Die()
    {
        _parentForm?.GameOver();
    }

    // Методы для бонусов
    public void ActivateSpeedBoost(float duration)
    {
        if (!_speedBoostActive)
        {
            _originalSpeed = _speed;
            _speed = _originalSpeed * 2;
            _speedBoostActive = true;
            _speedBoostRemaining = duration;
            _speedBoostTimer.Start();

            // Визуальный индикатор не меняем
            _parentForm?.UpdatePowerupIndicators();
        }
        else
        {
            // Продлеваем действие
            _speedBoostRemaining = Math.Max(_speedBoostRemaining, duration);
        }
    }

    private void UpdateSpeedBoost()
    {
        if (_speedBoostActive)
        {
            _speedBoostRemaining -= 0.1f;
            _parentForm?.UpdatePowerupIndicators();

            if (_speedBoostRemaining <= 0)
            {
                DeactivateSpeedBoost();
            }
        }
    }

    private void DeactivateSpeedBoost()
    {
        _speed = _originalSpeed;
        _speedBoostActive = false;
        _speedBoostRemaining = 0;
        _speedBoostTimer.Stop();
        _parentForm?.UpdatePowerupIndicators();
    }

    
    
    public void ActivateDoubleShot(float duration)
    {
        if (!_doubleShotActive)
        {
            _doubleShotActive = true;
            _doubleShotRemaining = duration;
            _doubleShotTimer.Start();

            // Визуальный индикатор - ничего не меняем с игроком
            _parentForm?.UpdatePowerupIndicators();
        }
        else
        {
            _doubleShotRemaining = Math.Max(_doubleShotRemaining, duration);
        }
    }

    private void UpdateDoubleShot()
    {
        if (_doubleShotActive)
        {
            _doubleShotRemaining -= 0.1f;
            _parentForm?.UpdatePowerupIndicators();

            if (_doubleShotRemaining <= 0)
            {
                DeactivateDoubleShot();
            }
        }
    }

    private void DeactivateDoubleShot()
    {
        _doubleShotActive = false;
        _doubleShotRemaining = 0;
        _doubleShotTimer.Stop();
        _parentForm?.UpdatePowerupIndicators();
    }

    
    
    public void ActivateShield(float duration)
    {
        if (!_hasShield)
        {
            _hasShield = true;
            _shieldRemaining = duration;
            _shieldTimer.Start();

            // Принудительно перерисовываем игрока с новым цветом
            this.Invalidate();

            _parentForm?.UpdatePowerupIndicators();
        }
        else
        {
            // Продлеваем действие
            _shieldRemaining = Math.Max(_shieldRemaining, duration);
        }
    }

    private void UpdateShield()
    {
        if (_hasShield)
        {
            _shieldRemaining -= 0.1f;
            _parentForm?.UpdatePowerupIndicators();

            if (_shieldRemaining <= 0)
            {
                DeactivateShield();
            }
        }
    }

    private void DeactivateShield()
    {
        _hasShield = false;
        _shieldRemaining = 0;
        _shieldTimer.Stop();

        // Принудительно перерисовываем игрока с обычным цветом
        this.Invalidate();

        _parentForm?.UpdatePowerupIndicators();
    }

    
    
    
    public void AddExtraLife()
    {
        if (_health < 3)
        {
            _health++;
            _parentForm?.UpdateHealthDisplay(_health);
        }
    }
}
