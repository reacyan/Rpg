using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "PlayerState_Run")]

public class Player_RunState : PlayerState
{
    public override void Enter()
    {
        anim.Play("Run");
    }

    public override void LogicUpdate()
    {
        anim.SetFloat("MoveX", input.currentAxes.x);
        anim.SetFloat("MoveY", input.currentAxes.y);

        player.SetVelocity(player.inputDirection.x * player.runSpeed, player.inputDirection.y * player.runSpeed);

        if (!input.move)
        {
            stateMachine.SwitchState(typeof(Player_IdleState));
        }
        else if (!input.Run)
        {
            stateMachine.SwitchState(typeof(Player_WalkState));
        }
    }

    public override void Exit()
    {
        player.SetZeroVelocity();
    }
}
