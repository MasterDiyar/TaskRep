using System.Collections.Generic;
using fptest.mobs;
using fptest.player;
using fptest.weapon.consumable;

namespace fptest.weapon.Swords;

using Godot;

public partial class Sword : Weapon
{
    protected Tween tween;
    protected bool isSwinging = false;
    [Export] public PackedScene SwingScene = GD.Load<PackedScene>("res://weapon/consumable/mediumSwing.tscn");
    public override string Name { get; set; }
    public override int Id { get; set; }
    public override float Damage { get; set; }
    public override float Durability { get; set; }
    public override float BaseCriticalModifier { get; set; }
    public override float AttackSpeed { get; set; }
    public override float Range { get; set; }
    public override int PierceCount { get; set; }
    public override float Stamina { get; set; }
    public Node Parent;

    public override void _Ready()
    {
        Parent = GetParent().GetParent();
        switch (Parent)
        {
            case Player player:
                Damage += player.Damage;
                break;
            case Entity entity:
                Damage += entity.Damage;
                break;
        }
        tween = GetTree().CreateTween();
    }

    public override void Attack()
    { 
      var swing = SwingScene.Instantiate<Swing>();
      swing.Damage = Damage;
      swing.Parent = GetParent().GetParent() as IEntity;
      swing.Position = GlobalPosition;
      swing.LifeTime = 0.3f;
      GetParent().GetParent().GetParent().GetParent().AddChild(swing);
    }

    public override void Reload()
    {
        
    }

    public override void OnEquip()
    {
        
    }

    public override void OnUnEquip()
    {
        
    }

    public override List<WeaponMod> AvailableMods { get; set; }
    
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("lm"))PlaySwing();
    }
    
    public void PlaySwing()
    {
        if (isSwinging) return;

        isSwinging = true;
        RotationDegrees = 0;

        tween = GetTree().CreateTween();
        tween.SetEase(Tween.EaseType.Out);
        tween.SetTrans(Tween.TransitionType.Quad);
        
        tween.TweenProperty(this, "rotation_degrees", 90, 0.3);

        tween.TweenCallback(Callable.From(() => Attack()));

        tween.TweenProperty(this, "rotation_degrees", 0, 0.12)
            .SetEase(Tween.EaseType.In)
            .SetTrans(Tween.TransitionType.Quad);

        tween.Finished += OnSwingFinished;
    }
    protected virtual void OnSwingFinished()
    {
        isSwinging = false;
    }
    
}