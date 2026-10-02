using Godot;

public partial class Movements : CharacterBody2D
{
	public float speed = 400f;
	public const float pushForce = 200f;


	public void SpeedUpdate()
	{
		if (Input.IsActionJustPressed("ups")) GD.Print(speed);
		if (Input.IsActionJustPressed("downs")) GD.Print(speed);
	}
    public override void _PhysicsProcess(double delta)
    {
        Vector2 dir = Vector2.Zero;
		SpeedUpdate();

		if (Input.IsActionPressed("up")) dir.Y -= 1;
		if (Input.IsActionPressed("down")) dir.Y += 1;
		if (Input.IsActionPressed("left")) dir.X -= 1;
		if (Input.IsActionPressed("right")) dir.X += 1;
		if (Input.IsActionJustPressed("ups")) speed += 50f; 
		if (Input.IsActionJustPressed("downs")) speed -= 50f;

		if (speed <= 0) speed = 50;
		

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