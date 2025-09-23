using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public override void _Ready()
	{
		
	}

	public override void _Process(double delta)
	{
		Move((float)delta);
	}
	float Speed = 300;
	private void Move(float delta)
	{
		Vector2 dir = Vector2.Zero;
		if (Input.IsActionPressed("w")){dir += Vector2.Up;}
		if (Input.IsActionPressed("s")){dir += Vector2.Down;}
		if (Input.IsActionPressed("a")){dir += Vector2.Left;}
		if (Input.IsActionPressed("d")){dir += Vector2.Right;}
		
		Position += (dir.Length() > 0) ? dir.Normalized()*Speed*delta : Vector2.Zero;
	}
}
