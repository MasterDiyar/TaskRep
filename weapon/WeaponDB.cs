using fptest.weapon.json;
using fptest.weapon.Swords;

namespace fptest.weapon;

using System.Collections.Generic;
using System.Threading.Tasks;
using Godot;

public class WeaponDB
{
    private Dictionary<int, SwordData> _swordCache = new ();
    
    public async Task InitializeAsync(string dictPath)
    {
        GD.Print("Loading weapon database...");
        
        var weaponDict = await WeaponLoader.LoadDictionaryAsync<int, string>(dictPath);

        foreach (var entry in weaponDict)
        {
            int id = entry.Key; 
            string weaponJsonPath = entry.Value;
            
            try
            {
                SwordData weapon = await WeaponLoader.LoadAsync<SwordData>(weaponJsonPath);
                _swordCache[id] = weapon;
                GD.Print($"Loaded weapon [{id}] {weapon.Name}");
            }
            catch (System.Exception e)
            {
                GD.PrintErr($"Failed to load weapon ID {id}: {e.Message}");
            }
        }
        
        

        GD.Print($"Weapon database loaded: {_swordCache.Count} items");
    }
    public  SwordData Get(int id)
     {
         if (_swordCache.TryGetValue(id, out SwordData weapon))
             return weapon;

         GD.PrintErr($"Weapon ID {id} not found in cache.");
         return null;
     }

    public Sword GetSwordById(int id)
    {
        Sword sword = new GenerableSword();
        SwordData data = _swordCache[id];
        
        sword.Id = data.Id;
        sword.Name = data.Name;
        sword.Damage = data.Damage;
        sword.Durability = data.Durability;
        sword.Stamina = data.Stamina;
        GD.Print($"Sword text path:{data.Path}");
        sword.Texture = GD.Load<Texture2D>(data.Path);
        sword.PierceCount = data.Pierce;
        sword.AttackSpeed = data.AttackSpeed;
        sword.Range = data.Range;
        sword.BaseCriticalModifier = data.Crit;
        
        return sword;
    }
}