using fptest.weapon;

namespace fptest.Items.BreakableItems;
using Godot;
public partial class TestBox:BreakableItem
{
    public override void _Ready()
    {
        MaxHp = 20;
        Hp = 20;
        
        
    }

    public void Touched(Node2D node)
    {
        if (node is Weapon wep)
        {
            Hp -= wep.Damage;
            
        }
        
        
        if (Hp <= 0) QueueFree();
    }
}