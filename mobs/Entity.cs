using Godot;

namespace fptest.mobs;

public partial class Entity : RigidBody2D
{
    public float MaxHp { get; }
    public float Hp {get; }
    public float Damage { get; }
    public Vector2 goPos = Vector2.Zero;
    public float Speed { get; }
    public enum State
    {
        GO,
        FIGHT,
        IDLE,
        HEAL
    }
    
    [Export] protected Area2D _visor;

    public override void _Ready()
    {
        _visor.BodyEntered += EntityFound;
    }
    
    protected virtual void Mind()
    {
        
    }

    protected virtual void EntityFound(Node2D node)
    {
        
    }
    

}