using Godot;
using System;

public partial class Spawner : Node2D
{
    public override void _Ready()
    {
        GD.Print("hello world");
    }

    public override void _Process(double delta)
    {
    }
}
