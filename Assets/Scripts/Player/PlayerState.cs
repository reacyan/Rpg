using UnityEngine;

public class PlayerState : ScriptableObject, IState
{

    protected PlayerController player;
    protected Animator anim;
    protected PlayerInput input;
    protected PlayerStateMachine stateMachine;
    protected float stateTimer;

    public void Initialize(Animator _anim, PlayerInput _input, PlayerStateMachine _stateMachine, PlayerController _player)
    {
        this.anim = _anim;
        this.input = _input;
        this.player = _player;
        this.stateMachine = _stateMachine;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }
}
