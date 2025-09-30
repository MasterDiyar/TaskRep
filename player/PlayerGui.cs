using Godot;
using System;

public partial class PlayerGui : CanvasLayer
{
	private Player Player;
	Line2D HpLine, ManaLine, StaminaLine;
	Label HpLabel, ManaLabel, StaminaLabel;
	public override void _Ready()
	{
		Player = GetParent<Player>();
		HpLine = GetNode<Line2D>("LeftUp/HpLine");
		ManaLine = GetNode<Line2D>("LeftUp/UiEmpty/ManaLine");
		StaminaLine = GetNode<Line2D>("LeftUp/StaminaLine");
		HpLabel = GetNode<Label>("LeftUp/HpIndex");
		ManaLabel = GetNode<Label>("LeftUp/ManaIndex");
		StaminaLabel = GetNode<Label>("LeftUp/StaminaIndex");
	}

	
	public override void _Process(double delta)
	{	ChangeLines();
	}

	void ChangeLines()
	{
		var hpPos = 50 + (Player.Hp / Player.MaxHp * 190);
		hpPos = Mathf.Clamp(hpPos, 50, 240);
		HpLine.SetPointPosition(1, new Vector2(hpPos, 35));
		HpLabel.Text = $"{Player.Hp}/{Player.MaxHp}";
		
		var mpPos = 50 + (Player.Mp / Player.MaxMp * 155);
		mpPos = Mathf.Clamp(mpPos, 50, 205);
		ManaLine.SetPointPosition(1, new Vector2(mpPos, 64));
		ManaLine.SetPointPosition(2, new Vector2(mpPos+20, 44));
		ManaLabel.Text = $"{Player.Mp}/{Player.MaxMp}";
		
		var stPos = 50 + (Player.Stamina / Player.MaxStamina * 150);
		stPos = Mathf.Clamp(stPos, 50, 200);
		StaminaLine.SetPointPosition(1, new Vector2(stPos, 85));
		StaminaLabel.Text = $"{Player.Stamina}/{Player.MaxStamina}";
		
		
		
	}
}
