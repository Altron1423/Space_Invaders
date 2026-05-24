namespace Space_Invaders;

public abstract partial class Projectile : UserControl
{
    protected int _speed;
    protected Form1 _parentForm;

    public Projectile()
    {
        InitializeComponent();
    }

    public void SetParentForm(Form1 form)
    {
        _parentForm = form;
    }

    public void Update(Entity[] entities)
    {
        if (IsOutOfBounds())
        {
            Delete();
        }
        else
        {
            // Движение снаряда (вниз для бонусов)
            Top += _speed; // Изменено: теперь += для движения вниз

            // Проверка столкновений
            if (entities != null)
            {
                foreach (Entity entity in entities)
                {
                    if (entity != null && entity.Visible && entity.IsHandleCreated && CheckIntersectsWith(entity))
                    {
                        IntersectsWith(entity);
                        // Всегда удаляем после столкновения
                        Delete();
                        break;
                    }
                }
            }
        }
    }

    protected void Delete()
    {
        _parentForm?.RemoveProjectile(this);
        Visible = false;
    }

    private bool CheckIntersectsWith(Entity entity)
    {
        return Bounds.IntersectsWith(entity.Bounds);
    }

    protected bool IsOutOfBounds()
    {
        // Для бонусов проверяем только нижнюю границу
        return Top > _parentForm?.ClientSize.Height + 100;
    }

    protected abstract void IntersectsWith(Entity entity);
}
