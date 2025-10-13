using System.Collections.Generic;
using fptest.Items;
using Godot;

namespace fptest.weapon;

public abstract partial class Weapon: Sprite2D, Item
{
    public abstract string Name { get; set; }
    public abstract int Id { get; set; }
    public abstract float Damage { get; set; }
    public abstract float Durability { get; set; }
    public abstract float BaseCriticalModifier { get; set; }
    public abstract float AttackSpeed { get; set; } 
    public abstract float Range { get; set; }
    public abstract float Stamina { get; set; }
    
    public abstract void Attack();
    public abstract void Reload();
    public abstract void OnEquip();
    public abstract void OnUnEquip();
    
    public abstract List<WeaponMod> AvailableMods { get; set; }
    public abstract int PierceCount { get; set; }

    public Texture2D GetItemTexture() => Texture;
}

public abstract class WeaponMod
{
    
}