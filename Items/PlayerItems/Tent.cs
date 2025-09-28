using Godot;
using System;
using fptest.Items;

public partial class Tent : BreakableItem
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MaxHp = 1024;
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
