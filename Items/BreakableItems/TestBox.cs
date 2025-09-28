using fptest.weapon;
using fptest.weapon.consumable;

namespace fptest.Items.BreakableItems;
using Godot;
public partial class TestBox:BreakableItem
{
    public override void _Ready()
    {
        MaxHp = 100;
        base._Ready();
    }
}