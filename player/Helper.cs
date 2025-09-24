using Godot;
using System;
using fptest.mobs;

public partial class Helper : Entity
{
	State state = State.GO;
	
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
				break;
		}
	}

	private void Fight()
	{
		
	}
	public void GoTo(Vector2 pos)
	{
		goPos = pos;
	}
}
