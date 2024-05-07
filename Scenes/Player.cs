using Godot;
using System;
using System.Drawing;
using System.Net.Security;

public partial class Player : AnimatableBody2D
{

	const int Speed = 10;
	Vector2 VerticalMovementLimits;

	float height;

	public override void _Ready()
	{
		Node parent = GetParent();
		Area2D area2DNode = parent.GetNodeOrNull<Area2D>("Play Area");
		CollisionShape2D collisionShape2D = area2DNode.GetNode<CollisionShape2D>("CollisionShape2D");
		Sprite2D sprite2DNode = area2DNode.GetNodeOrNull<Sprite2D>("Black");
		VerticalMovementLimits = new Vector2(0, sprite2DNode.Texture.GetHeight());
		VerticalMovementLimits *= sprite2DNode.Scale;

		height = GetNode<Sprite2D>("Sprite2D").Texture.GetHeight();
		var scale = GetNode<Sprite2D>("Sprite2D").Scale;
		height = height * scale.Y;

		VerticalMovementLimits = VerticalMovementLimits - new Vector2(-height/2, height/2);
	}

    public override void _Process(double delta)
    {
        base._Process(delta);

		if (Input.IsActionPressed("Going UP"))
		{
			float positionY;
			if (GlobalPosition.Y > VerticalMovementLimits.X) {
				positionY = -1 * Speed;
				positionY = GlobalPosition.Y <= 0 + height/2 ? VerticalMovementLimits.X : positionY;
				Position += new Vector2(0, positionY);
			}			
		}

		if (Input.IsActionPressed("Going DOWN"))
		{
			float positionY;
			if (GlobalPosition.Y < VerticalMovementLimits.Y) {
				positionY = Speed;
				positionY = GlobalPosition.Y <= VerticalMovementLimits.Y ? positionY : VerticalMovementLimits.Y; 
				Position += new Vector2(0, positionY);
			}
		}
    }
} 
