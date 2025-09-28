using Godot;
using System;
using fptest.mobs;

public partial class Helper : Entity
{
	State state = State.GO;
	

	public override void _Ready()
	{
		Speed = 30;
		Hp = 20;
		Team = 1;
	}

	public override void _Process(double delta)
	{
		switch (state)
		{
			case State.GO:
				if (GlobalPosition != goPos) {
					var angle = GlobalPosition.AngleToPoint(goPos);
					Position += new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Speed * (float)delta;
				} ;
				break;
			case State.FIGHT:
				Fight();
				break;
			case State.IDLE:
				break;
			case State.HEAL:
				Hp += 2;
				SearchHeal();
				if (Hp >= MaxHp) state = State.IDLE;
				break;
		}
	}

	public void SetState(int num)
	{
		state = (State)num;
	}

	private void Fight()
	{
		if (Hp < MaxHp/4) state = State.GO;
		SearchHeal();
	}

	public void SearchHeal()
	{
		var isChildHere = false;
		Tent node = null;
		foreach (var child in GetParent().GetChildren()) {
			if (child is not Tent tent) continue;
			isChildHere = true;
			node = tent;
		}
		if (isChildHere) GoTo(node.Position);
		else GD.Print("Tent not found");
	}
	public void GoTo(Vector2 pos)
	{
		goPos = pos;
	}

	protected override void EntityFound(Node2D node)
	{
		if (node is Tent tent)
		{
			state = State.HEAL;
		}
	}
}
