using Godot;

namespace fptest.mobs;

public partial class Enemy: Entity
{
    State state = State.IDLE;

    public Player Player;

    protected override void EntityFound(Node2D node)
    {
        if (node is Player player)
        {
            Player = player;
            state = State.FIGHT;
        }
    }
    
    public virtual void Attack()
    {
        
    }
}