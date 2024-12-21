using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "PlayerState_Run")]

public class Player_RunState : PlayerState
{
    public override void Enter()
    {
        base.Enter();

        anim.Play("Run");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        anim.SetFloat("MoveX", input.currentAxes.x);
        anim.SetFloat("MoveY", input.currentAxes.y);

        player.SetVelocity(input.currentAxes.x * player.runSpeed, input.currentAxes.y * player.runSpeed);

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
        base.Exit();

        player.SetZeroVelocity();
    }
}
