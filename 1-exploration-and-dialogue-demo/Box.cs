using Godot;

public partial class Box : CharacterBody2D
{
    [Export] public float Speed = 30f;

    public void TryMove(Vector2 direction)
    {
        // Attempt to move the box in the given direction
        Velocity = direction.Normalized() * Speed;
        MoveAndSlide();
    }
}
