using UnityEngine;

public class PlayerState : ScriptableObject, IState
{

    protected PlayerController player;
    protected Animator anim;
    protected PlayerInput input;
    protected PlayerStateMachine stateMachine;
    protected float stateTimer;

    protected bool triggerBack;

    public void Initialize(Animator _anim, PlayerInput _input, PlayerController _player, PlayerStateMachine _stateMachine)
    {
        this.anim = _anim;
        this.input = _input;
        this.player = _player;
        this.stateMachine = _stateMachine;
    }

    public virtual void Enter()
    {
        triggerBack = false;
    }

    public virtual void Exit()
    {
        triggerBack = true;
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }
}
