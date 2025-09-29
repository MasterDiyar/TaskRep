using System.Collections.Generic;
using fptest.player;
using fptest.weapon;

namespace fptest.Items;
using Godot;

public partial class BreakableItem:RigidBody2D, IEntity
{
    public float Hp { get; set; } = 0;
    public int Team { get; set; } = 1024;
    [Export]public float MaxHp { get; set; }
    

    public override void _Ready()
    {
        Hp = MaxHp;
    }

    public virtual void GetDamage(float damage, List<WeaponMod> mods)
    {
        GD.Print("Taking damage: " + damage);
        Hp -= damage;
        GD.Print("Hp: " + Hp);
        if (Hp < 0) QueueFree();
    }
    
}