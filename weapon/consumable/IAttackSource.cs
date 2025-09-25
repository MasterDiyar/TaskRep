using System.Collections.Generic;
using fptest.player;

namespace fptest.weapon.consumable;

public interface IAttackSource
{
    int Damage { get; }
    IEntity Owner { get; }
    List<WeaponMod> Mods { get; }
}