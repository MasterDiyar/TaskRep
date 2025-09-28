using Godot;
using System;
using fptest.weapon.consumable;

public partial class MediumSwing : Swing
{
    public override void _Ready()
    {
        base._Ready();
        Damage += 10;
    }
}
