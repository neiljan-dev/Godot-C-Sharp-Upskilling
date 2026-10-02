using Godot;
using System;

public partial class Area : Area2D
{
    [Export(PropertyHint.File, "*.tscn")]
    public string TargetScene { get; set; }

    public override void _Ready()
    {
        BodyEntered += Entering; 
    }

    private void Entering(Node body)
    {
        if (body.IsInGroup("Player") && !string.IsNullOrEmpty(TargetScene))
        {
            GetTree().ChangeSceneToFile(TargetScene);
        }
    }
}
