using fptest.player;

namespace fptest.weapon.consumable;
using Godot;

public partial class Swing : Area2D
{
    public float Damage { get; set; }
    public float LifeTime { get; set; }
    public IEntity Parent { get; set; }
    
    [Export]public AnimatedSprite2D Sprite { get; set; }

    
    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }

    public void OnBodyEntered(Node2D body)
    {
        if (body is not IEntity entity) return;
        if (entity.Team == Parent.Team) return;
        
        
        
    }
}