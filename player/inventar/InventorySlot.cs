using Godot;

namespace fptest.player;

public partial class InventorySlot: TextureRect
{
    [Export] public int SlotIndex { get; set; }
    private InventoryUI _inventoryUI;

    public override void _Ready()
    {
        _inventoryUI = GetParent<InventoryUI>();
        MouseFilter = MouseFilterEnum.Pass; // разрешает события мыши
    }

    public override Variant _GetDragData(Vector2 atPosition)
    {
        var item = _inventoryUI.Inventory.Get(SlotIndex);

        var dragIcon = new TextureRect
        {
            Texture = item.GetItemTexture(),
            Scale = new Vector2(0.8f, 0.8f)
        };
        SetDragPreview(dragIcon);

        return SlotIndex;
    }

    public override bool _CanDropData(Vector2 atPosition, Variant data)
    {
        return data.VariantType == Variant.Type.Int;
    }

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        int from = (int)data;
        int to = SlotIndex;
        _inventoryUI.ChangeSlots(from, to);
    }

    public void UpdateIcon()
    {
        var item = _inventoryUI.Inventory.Get(SlotIndex);
        Texture = item?.GetItemTexture();
    }
}