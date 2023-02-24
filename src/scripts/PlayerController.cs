using Godot;

public partial class PlayerController : Node
{
    public override void _Ready()
    {
        GD.Print("Hello World!");
    }

    public override void _Process(double delta)
    {
        if (Input.IsKeyPressed(Key.W))
        {
            GD.Print("W is pressed");
        }
    }
}
