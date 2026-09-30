using Godot;

public partial class Movements : CharacterBody2D
{
    [Export] public float speed = 200f;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 direction = Vector2.Zero;

        if (Input.IsActionPressed("up")) direction.Y -= 1;
        if (Input.IsActionPressed("down")) direction.Y += 1;
        if (Input.IsActionPressed("left")) direction.X -= 1;
        if (Input.IsActionPressed("right")) direction.X += 1;

        Velocity = direction.Normalized() * speed;

        // Detect collisions
        KinematicCollision2D collision = MoveAndCollide(Velocity * (float)delta);

        if (collision != null && collision.GetCollider() is Box box)
        {
            // Try to move the box in the same direction
            box.TryMove(direction);
        }
        else
        {
            // If no collision, just slide normally
            MoveAndSlide();
        }
    }
}
