using Godot;

public partial class Movements : CharacterBody2D
{
	public const float speed = 200f;
	public const float pushForce = 50f;


    public override void _PhysicsProcess(double delta)
    {
        Vector2 dir = Vector2.Zero;

		if (Input.IsActionPressed("up")) dir.Y -= 1;
		if (Input.IsActionPressed("down")) dir.Y += 1;
		if (Input.IsActionPressed("left")) dir.X -= 1;
		if (Input.IsActionPressed("right")) dir.X += 1;

		Velocity = dir.Normalized() * speed;
		MoveAndSlide();

		for (int i = 0; i < GetSlideCollisionCount(); i++){
			
			var collision = GetSlideCollision(i);

			if (collision.GetCollider() is CharacterBody2D box)
			{
				Vector2 pushDir = -collision.GetNormal();
				box.Velocity = pushDir * pushForce;
			}
		}
    }

}