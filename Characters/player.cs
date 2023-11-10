using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
    public int Speed { get; set; } = 200;


	public override void _PhysicsProcess(double delta)
	{
		var playerDirection = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("right"))
		{
			playerDirection.X += 1;
		}

		if (Input.IsActionPressed("left"))
		{
			playerDirection.X -= 1;
		}

		if (Input.IsActionPressed("down"))
		{
			playerDirection.Y += 1;
		}

		if (Input.IsActionPressed("up"))
		{
			playerDirection.Y -= 1;
		}		

		if (playerDirection != Vector2.Zero)
		{
			playerDirection = playerDirection.Normalized() * Speed;
			Velocity = playerDirection;
			MoveAndSlide();
			var animationTree = GetNode<AnimationTree>("AnimationTree");

			animationTree.Set("parameters/", playerDirection);
		}

		
	}
}
