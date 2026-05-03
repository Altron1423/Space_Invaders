namespace Space_Invaders;

public abstract partial class Projectile : UserControl
{
    protected int _speed;
    
    public Projectile()
    {
        InitializeComponent();
    }


    public void Update(Entity[] m)
    {
        if (IsOutOfBounds())
        {
            Delete();
        }
        else
        {
            Entity entity;
            for (int i = 0; i < m.Length; i++)
            {
                entity = m[i];
                if (CheckIntersectsWith(entity))
                {
                    IntersectsWith(entity);
                    Delete();
                }
            }
        }
    }
    
    protected void Delete()
    {
        
    }

    private bool CheckIntersectsWith(Entity entity)
    {
        return false;
    }
    protected bool IsOutOfBounds() {return false;}
    
    protected abstract void IntersectsWith(Entity entity);
}
