using Godot;
using System;
using System.Collections.Generic;
using fptest.player;
using fptest.weapon;

public partial class Player : CharacterBody2D, IEntity
{
	public float Speed = 30;
	public float Damage = 10;
	public int Team { get; set; } = 1;

	public float MaxHp { get; set; } = 20;
	public float Hp { get; set; }

	public override void _Ready()
	{
		
	}

	public override void _Process(double delta)
	{
		
	}
	
	

	
	public void GetDamage(float damage, List<WeaponMod> Mods)
	{
        
	}

	
}
