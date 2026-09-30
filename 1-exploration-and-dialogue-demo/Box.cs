using Godot;

public partial class Box : CharacterBody2D
{
    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;
		velocity = velocity.MoveToward(Vector2.Zero, 800f * (float)delta);

		Velocity = velocity;

		MoveAndSlide();
    }


}
