using Godot;

namespace toybox.Scripts;

public partial class CameraController : Camera2D
{
    private const int MovementSpeed = 500;

    public override void _PhysicsProcess(double delta)
    {
        var input = GetInput();
        var velocity = input * MovementSpeed;
        Translate(velocity * (float)delta);
    }

    private static Vector2 GetInput()
    {
        var vector = new Vector2();

        if (Input.IsActionPressed("ui_right"))
            vector.X += 1;
        if (Input.IsActionPressed("ui_left"))
            vector.X -= 1;
        if (Input.IsActionPressed("ui_down"))
            vector.Y += 1;
        if (Input.IsActionPressed("ui_up"))
            vector.Y -= 1;

        return vector.Normalized();
    }
}
