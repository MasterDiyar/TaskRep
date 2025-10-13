using Godot;
using System;
using fptest.weapon;

public partial class ItemLoader : Node
{
	[Signal] public delegate void WeaponsLoadedEventHandler();

	public WeaponDB WDB = new WeaponDB(); 
	
	public bool Loaded = false;
	//ETO WEAPONDATABASE
	public override async void _Ready()
	{
		await WDB.InitializeAsync("weapon/json/weapon_dict.json");
		
		GD.Print("DB loaded");
		Loaded = true;
		EmitSignal(SignalName.WeaponsLoaded);
	}
	
}
