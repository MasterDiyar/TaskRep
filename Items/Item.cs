using Godot;

namespace fptest.Items;

public interface Item
{
    string Name { get; }
    int Id { get; }
    Texture2D GetItemTexture();
    
}