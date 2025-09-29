using System.Collections.Generic;
using Godot;

namespace fptest.player;

public partial class UserControl : Node2D
{
    [Export] private Player _player;

    private List<Helper> _friends = [];
    
    public bool AlwaysFormation = false;
    public double Tickrate = 0, NeedRate = 0.25;

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey { Keycode: Key.Shift })
        {
            var daddy = _player.GetParent();
            _friends = [];
            foreach (var sons in daddy.GetChildren())
                if (sons is Helper helper) AddFriend(helper);
        }

        if (@event is InputEventKey { Keycode: Key.E })
            foreach (var friend in _friends)
                friend.SearchHeal();
            
        
        if (@event is InputEventKey { Keycode: Key.R, Pressed: true })
            AlwaysFormation = !AlwaysFormation;
    }

    public override void _Process(double delta)
    {
        Tickrate += delta;
        if (AlwaysFormation && Tickrate > NeedRate)
        {
            Tickrate = 0;
            SetFormation(_friends.Count - 1);
        }
        
        Move((float)delta);
    }

    public void AddFriend(Helper friend)
    {
        if (!_friends.Contains(friend))
            _friends.Add(friend);
    }
    
    public void SetFormation(int type)
    {
        switch (type)
        {
            case 0:
                _friends[0].GoTo(_player.GlobalPosition + new Vector2(0f, 50f));
                break;
            case 1:
                _friends[0].GoTo(_player.GlobalPosition + new Vector2(0f, 50f));
                _friends[1].GoTo(_player.GlobalPosition + new Vector2(0f, -50f));
                break;
            default:
                int fCount = _friends.Count;
                for (var i = 0; i < fCount; i++)
                {
                    _friends[i].SetState(0);
                    _friends[i].GoTo(_player.GlobalPosition + 50 *new Vector2(Mathf.Cos(Mathf.Pi*2 * i /fCount), Mathf.Sin(Mathf.Pi*2 * i /fCount)));
                }
                break;
            
        }
    }
    
    private void Move(float delta)
    {
        Vector2 dir = Vector2.Zero;
        if (Input.IsActionPressed("w")){dir += Vector2.Up;}
        if (Input.IsActionPressed("s")){dir += Vector2.Down;}
        if (Input.IsActionPressed("a")){dir += Vector2.Left;}
        if (Input.IsActionPressed("d")){dir += Vector2.Right;}
		
        _player.Position += (dir.Length() > 0) ? dir.Normalized()*_player.Speed*delta : Vector2.Zero;
    }
    
    
    
}