using Godot;
using System;
using System.Collections.Generic;
using fptest.player;
using fptest.weapon;

public partial class Player : CharacterBody2D, IEntity
{
	float Speed = 30;
	public float Damage = 10;
	public int Team { get; set; } = 1;
	public override void _Ready()
	{
		
	}

	public override void _Process(double delta)
	{
		Move((float)delta);
	}
	
	private void Move(float delta)
	{
		Vector2 dir = Vector2.Zero;
		if (Input.IsActionPressed("w")){dir += Vector2.Up;}
		if (Input.IsActionPressed("s")){dir += Vector2.Down;}
		if (Input.IsActionPressed("a")){dir += Vector2.Left;}
		if (Input.IsActionPressed("d")){dir += Vector2.Right;}
		
		Position += (dir.Length() > 0) ? dir.Normalized()*Speed*delta : Vector2.Zero;
	}

	
	public void GetDamage(float damage, List<WeaponMod> Mods)
	{
        
	}

	
}
