using System.Collections.Generic;
using fptest.player;
using fptest.weapon;
using Godot;

namespace fptest.mobs;

public partial class Entity : RigidBody2D, IEntity
{
    public float MaxHp { get;set; }
    public float Hp {get; set;}
    public float Damage { get; set;}
    public Vector2 goPos = Vector2.Zero;
    public float Speed { get; set; }

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

    public virtual void GetDamage(float damage, List<WeaponMod> Mods)
    {
        
    }

    public int Team { get; set; }
}