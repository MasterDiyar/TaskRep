using Godot;
using System;

public partial class Helper : RigidBody2D
{
	public enum State
	{
		GO,
		FIGHT,
		IDLE,
		HEAL
	}
	State state = State.GO;
	
	Vector2 _goPos = Vector2.Zero;
	private float Speed = 300;
	
	public override void _Ready()
	{
	}
	public override void _Process(double delta)
	{
		switch (state)
		{
			case State.GO:
				if (GlobalPosition != _goPos) {
					var angle = GlobalPosition.AngleToPoint(_goPos);
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
		_goPos = pos;
	}
}
