using UnityEngine;

public class MoveLeft : Command
{
    private PlayerMovement _playermovement;

    public MoveLeft(PlayerMovement playermovement)
    {
        _playermovement = playermovement;
    }

    public override void Execute()
    {
        
    }
}
