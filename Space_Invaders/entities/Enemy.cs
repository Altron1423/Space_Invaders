using System.ComponentModel;

namespace Space_Invaders;

public enum EnemyType { Normal, Fast, Armored }

public partial class Enemy : Entity
{
    public EnemyType _type;
    public int _points;
    public double _shootChance;

    public Enemy()
    {
        InitializeComponent();
    }
    
    public Enemy(IContainer container)
    {
        container.Add(this);
    
        InitializeComponent();
    }
    
    public override void Die() {}
}
