using System.Collections.Generic;

namespace fptest.weapon;

public abstract class Weapon
{
    public abstract string Name { get; }
    public abstract float Damage { get; set; }
    public abstract float Durability { get; set; }
    public abstract float BaseCriticalModifier { get; set; }
    public abstract float AttackSpeed { get; } 
    public abstract float Range { get; }
    
    public abstract void Attack();
    public abstract void Reload();
    public abstract void OnEquip();
    public abstract void OnUnEquip();
    
    public abstract List<WeaponMod> AvailableMods { get; }
    public abstract int PierceCount { get; } 
}

public abstract class WeaponMod
{
    
}