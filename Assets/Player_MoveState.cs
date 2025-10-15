using UnityEditor.Tilemaps;
using UnityEngine;

public class Player_MoveState : Player_GroundedState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Player_MoveState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (player.moveInput.x == 0)
            stateMachine.ChangeState(player.IdleState);

        player.SetVelocity(player.moveInput.x * player.moveSpeed, rb.linearVelocity.y);

    }
}
