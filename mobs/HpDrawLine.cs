using Godot;
using System;
using fptest.player;

public partial class HpDrawLine : Node2D
{
    [Export] public Vector2 BarSize = new Vector2(48, 6);
    [Export] public float VerticalGap = 5f;
    [Export] public Color BackgroundColor = new Color(0f, 0f, 0f, 0.6f);
    [Export] public Color ForegroundColor = new Color(0.0f, 1.0f, 0.0f);
    [Export] public Color BorderColor = new Color(0f, 0f, 0f, 1f);
    [Export] public float BorderWidth = 1f;

    private IEntity _entity;
    private float _spriteHeight = 0f;

    public override void _Ready()
    {
        // Родитель должен реализовывать IEntity
        _entity = GetParent() as IEntity;
        if (_entity == null)
        {
            GD.PushWarning($"{Name}: Родитель {GetParent().Name} не реализует IEntity!");
            return;
        }

        // Пытаемся найти mainImage
        var node = GetParent().GetNodeOrNull("mainImage");

        if (node is Sprite2D sp && sp.Texture != null)
        {
            Vector2 size;
            if (sp.RegionEnabled)
                size = sp.RegionRect.Size; // реальный регион
            else
                size = sp.Texture.GetSize();

            _spriteHeight = size.Y * sp.Scale.Y;
        }
        else if (node is AnimatedSprite2D spr && spr.SpriteFrames != null)
        {
            var tex = spr.SpriteFrames.GetFrameTexture(spr.Animation, 0);
            if (tex != null)
                _spriteHeight = tex.GetHeight() * spr.Scale.Y;
        }
    }

    public override void _Process(double delta)
    {
        QueueRedraw();
    }

    public override void _Draw()
    {
        if (_entity == null) return;
        if (_entity.Hp >= _entity.MaxHp) return; // рисуем только если хп не полное

        float ratio = (_entity.MaxHp > 0f) ? Mathf.Clamp(_entity.Hp / _entity.MaxHp, 0f, 1f) : 0f;

        // Y-координата верхней точки
        float topY = -_spriteHeight / 2f;
        if (_spriteHeight <= 0f)
            topY = 0f; // fallback если текстуры нет

        // центрируем полоску
        float barCenterY = topY - VerticalGap - (BarSize.Y / 2f);
        Vector2 barTopLeft = new Vector2(-BarSize.X / 2f, barCenterY - BarSize.Y / 2f);

        // фон
        Rect2 bgRect = new Rect2(barTopLeft, BarSize);
        DrawRect(bgRect, BackgroundColor);

        // заполнение
        Vector2 fillSize = new Vector2(BarSize.X * ratio, BarSize.Y);
        Rect2 fillRect = new Rect2(barTopLeft, fillSize);
        DrawRect(fillRect, ForegroundColor);

        // рамка
        DrawLine(bgRect.Position, bgRect.Position + new Vector2(bgRect.Size.X, 0f), BorderColor, BorderWidth);
        DrawLine(bgRect.Position + new Vector2(bgRect.Size.X, 0f), bgRect.Position + new Vector2(bgRect.Size.X, bgRect.Size.Y), BorderColor, BorderWidth);
        DrawLine(bgRect.Position + new Vector2(0f, bgRect.Size.Y), bgRect.Position + new Vector2(bgRect.Size.X, bgRect.Size.Y), BorderColor, BorderWidth);
        DrawLine(bgRect.Position, bgRect.Position + new Vector2(0f, bgRect.Size.Y), BorderColor, BorderWidth);
    }
}
