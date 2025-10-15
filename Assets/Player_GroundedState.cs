using UnityEngine;

public abstract class Player_GroundedState : EntityState
{
    protected Player_GroundedState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (input.Player.Jump.WasPerformedThisFrame())
            stateMachine.ChangeState(player.JumpState);
    }
}
