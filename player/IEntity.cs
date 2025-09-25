using System.Collections.Generic;
using fptest.weapon;

namespace fptest.player;

public interface IEntity
{
    void GetDamage(float damage, List<WeaponMod> weapons);
    int Team { get; }
}