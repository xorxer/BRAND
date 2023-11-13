using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
    public int Speed { get; set; } = 200;


	public override void _PhysicsProcess(double delta)
	{
		var playerDirection = Vector2.Zero; // The player's movement vector.
		var player = GetNode<Sprite2D>("Body");

		// Player moves in the direction of the input
		// Where WASD are the arrow keys
		if (Input.IsActionPressed("right"))
		{
			playerDirection.X += 1;
			// Does not flip the sprite horizontally
			player.FlipH = false;
		}
		if (Input.IsActionPressed("left"))
		{
			playerDirection.X -= 1;
			// Flips the sprite horizontally
			player.FlipH = true;
		}
		if (Input.IsActionPressed("down"))
		{
			playerDirection.Y += 1;
		}
		if (Input.IsActionPressed("up"))
		{
			playerDirection.Y -= 1;
		}		

		playerDirection = playerDirection.Normalized() * Speed;
		Velocity = playerDirection;

		var animationTree = GetNode<AnimationTree>("AnimationTree");
		// AnimationNodeStateMachinePlayback stateMachine = (AnimationNodeStateMachinePlayback)animationTree.Get("parameters/playback");
		if (playerDirection != Vector2.Zero)
		{
			// stateMachine.Travel("Move");
			animationTree.Set("parameters/Move/blend_position", playerDirection);
			// animationTree.Set("parameters/conditions/Idle", playerDirection);
			MoveAndSlide();
		}

		
	}
}
