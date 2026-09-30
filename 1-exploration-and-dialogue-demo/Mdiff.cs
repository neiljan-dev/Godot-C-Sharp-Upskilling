using Godot;

public partial class Mdiff : CharacterBody2D{
	public const float speed = 200f;

    public override void _PhysicsProcess(double delta)
    {
		Vector2 direction = Vector2.Zero;

        if (Input.IsActionPressed("ups"))
			direction.Y -= 1;
		if (Input.IsActionPressed("downs"))
			direction.Y += 1;
		if (Input.IsActionPressed("lefts"))
			direction.X -= 1;
		if (Input.IsActionPressed("rights"))
			direction.X += 1;
		

		Velocity = direction.Normalized() * speed;
		Position += Velocity * (float)delta;
    }

}
