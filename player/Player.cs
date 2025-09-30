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
	
	public float MaxMp { get; set; } = 20;
	public float Mp;

	public float MaxStamina { get; set; } = 20;
	public float Stamina;
	
	public override void _Ready()
	{
		Hp = MaxHp;
		Mp = MaxMp;
		Stamina = MaxStamina;
	}

	public override void _Process(double delta)
	{
		
	}
	
	

	
	public void GetDamage(float damage, List<WeaponMod> mods)
	{
        Hp -= Mathf.Clamp(damage, 0, MaxHp);
	}

	
}
