using fptest.player;

namespace fptest.weapon.consumable;
using Godot;

public partial class Swing : Area2D
{
    public float Damage { get; set; }
    public float LifeTime { get; set; }
    public IEntity Parent { get; set; }

    private AddAction Begin, End;
    
    [Export]public AnimatedSprite2D Sprite { get; set; }
    [Export]public AudioStreamPlayer2D Audio { get; set; }
    [Export]public Timer Timer { get; set; }
    
    public override void _Ready()
    {
        Timer.WaitTime = LifeTime;
        BodyEntered += OnBodyEntered;
        
        Begin.Run();
        Timer.Timeout += () => {End.Run(); QueueFree();};
    }

    public void OnBodyEntered(Node2D body)
    {
        if (body is not IEntity entity) return;
        if (entity.Team == Parent.Team) return;
        
        
        
    }
}