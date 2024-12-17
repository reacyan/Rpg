using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class Player_IdleState : PlayerState
{
    public override void Enter()
    {
        anim.Play("Idle");
    }

    public override void LogicUpdate()
    {
        anim.SetFloat("MoveX", input.currentAxes.x);
        anim.SetFloat("MoveY", input.currentAxes.y);

        if (input.move & input.Run)
        {
            stateMachine.SwitchState(typeof(Player_RunState));
        }
        else if (input.move)
        {
            stateMachine.SwitchState(typeof(Player_WalkState));
        }
    }

    public override void Exit()
    {
    }
}
