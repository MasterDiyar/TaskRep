using System.Collections.Generic;
using fptest.weapon.consumable;

namespace fptest.weapon.Swords;

using Godot;

public partial class Swords : Weapon
{
    public override string Name { get; }
    public override float Damage { get; set; }
    public override float Durability { get; set; }
    public override float BaseCriticalModifier { get; set; }
    public override float AttackSpeed { get; }
    public override float Range { get; }

    public override void _Ready()
    {
        if (GetParent().GetParent() is Player player)
            
    }

    public override void Attack()
    { 
      var swing = GD.Load<PackedScene>("res://weapon/consumable/mediumSwing.tscn").Instantiate<Swing>();
      swing.Damage = Damage;
      
      
    }

    public override void Reload()
    {
        
    }

    public override void OnEquip()
    {
        
    }

    public override void OnUnEquip()
    {
        
    }

    public override List<WeaponMod> AvailableMods { get; }
    public override int PierceCount { get; }
}