using UnityEngine;

public class MoveRight : Command
{
    private PlayerMovement _playermovement;

    public MoveRight(PlayerMovement playermovement)
    {
        _playermovement = playermovement;
    }

    public override void Execute()
    {

    }
}
