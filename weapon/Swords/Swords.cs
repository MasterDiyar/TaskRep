using System.Collections.Generic;
using fptest.mobs;
using fptest.player;
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
        Node Parent = GetParent().GetParent();
        switch (Parent)
        {
            case Player player:
                Damage += player.Damage;
                break;
            case Entity entity:
                Damage += entity.Damage;
                break;
        }
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("lm"))Attack();
    }

    public override void Attack()
    { 
      var swing = GD.Load<PackedScene>("res://weapon/consumable/mediumSwing.tscn").Instantiate<Swing>();
      swing.Damage = Damage;
      swing.Parent = GetParent().GetParent() as IEntity;
      swing.Position = GlobalPosition;
      swing.LifeTime = 0.3f;
      GetParent().GetParent().GetParent().GetParent().AddChild(swing);
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