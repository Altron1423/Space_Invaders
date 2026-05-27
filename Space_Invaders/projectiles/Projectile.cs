using System.Security.Cryptography;

namespace Space_Invaders;

public abstract partial class Projectile : UserControl
{
    protected int _speed;
    protected Brush _brush;
    protected bool _delete;
    
    protected Form1 _parentForm;

    public Projectile()
    {
        InitializeComponent();
    }

    public void SetParentForm(Form1 form)
    {
        _parentForm = form;
    }

    public void Update()
    {
        // Console.WriteLine($"IsOutOfBounds() {IsOutOfBounds()}");
        if (IsOutOfBounds())
        {
            _delete = true;
        }
        else
        {
            // �������� ������� (���� ��� �������)
            Top += _speed; // ��������: ������ += ��� �������� ����
        }
        // Console.WriteLine($"_delete {_delete}");
    }

    public void TestInteractWith(List<Entity> entities)
    {
        foreach (Entity entity in entities)
        {
            TestInteractWith(entity);
            if (_delete)
                break;
        }
    }
    
    public void TestInteractWith(Entity entity)
    {
        // Console.WriteLine($"CheckIntersectsWith {CheckIntersectsWith(entity)}");
        if (entity.Visible && entity.IsHandleCreated && CheckIntersectsWith(entity))
        {
            IntersectsWith(entity);
            _delete = true;
        }
    }
    
    protected void Draw(object sender, PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;
        graphics.FillRectangle(_brush, 0, 0, Width - 1, Height - 1);
    }
    
    private bool DotInRect(int x1, int y1, int x2, int y2, int px, int py)
    {
        if ( x1 <= px && px <= x2 && y1 <= py && py <= y2 )
            return true;
        return false;
    }
    
    
    private bool CheckIntersectsWith(Entity entity)
    {
        return DotInRect(
            entity.Left, entity.Top,
            entity.Right, entity.Bottom,
            Left, Top) || DotInRect(
            entity.Left, entity.Top,
            entity.Right, entity.Bottom,
            Right, Bottom);
    }

    protected bool IsOutOfBounds()
    {
        return Top <= 0;
    }
    
    protected abstract void IntersectsWith(Entity entity);
    
    public bool Delete
    {
        get { return _delete; }
    }
}
