
using fptest.weapon;

namespace fptest.player;


using Godot;
using System.Collections.Generic;

public partial class InventoryUI : Control
{
    public Inventory Inventory { get; private set; } = new();
    private ItemLoader loader;
    

    public override void _Ready()
    {
        loader = GetTree().Root.GetNode<ItemLoader>("ItemLoader");
        if (loader.Loaded)
            OnWeaponLoaded();        
        else
            loader.WeaponsLoaded += OnWeaponLoaded;
        GD.Print("InventoryUI ready");
        
    }

    void OnWeaponLoaded()
    {
        GD.Print("GAYDAY ");
        var sword = loader.WDB.GetSwordById(1);
        
        Inventory.Set(0, sword);
        UpdateAllSlots();
    }

    public void ChangeSlots(int from, int to)
    {
        Inventory.Swap(from, to);
        UpdateAllSlots();
    }

    private void UpdateAllSlots()
    {
        foreach (var child in GetChildren())
        {
            if (child is InventorySlot slot)
                slot.UpdateIcon();
        }
    }
}
