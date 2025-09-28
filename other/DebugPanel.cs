using Godot;
using System;

public partial class DebugPanel : Node2D
{
	[Export]private LineEdit codeLine;
	[Export]private Node2D map;
	public override void _Ready()
	{
		codeLine.TextSubmitted += CodeSubmitted;
	}

	
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("slsh"))
		{
			codeLine.Visible = !codeLine.Visible;
		}
	}

	private void CodeSubmitted(string code)
	{
		var codelow = code.ToLower();
		var blocks = codelow.Split([' ']);
		switch (blocks[0])
		{
			case "add":
				GD.Print("Adding " + blocks[1]);
				if (blocks[1].Equals("helper"))
					for (int i = 0; i < blocks[2].ToInt(); i ++)
						map.AddChild(GD.Load<PackedScene>("res://player/helper.tscn").Instantiate());
				break;
			case "remove":
				if (blocks[1].Equals("helper")) {
					foreach (var childs in map.GetChildren())
						if (childs is Helper helper) {
							GD.Print(helper.GetName()+" removed");
							helper.QueueFree();
						}
					
				}
				break;
		}
	}
}
