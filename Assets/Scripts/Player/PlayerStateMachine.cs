using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] PlayerState[] states;
    PlayerInput input;

    PlayerController player;

    Animator anim;

    private void Awake()
    {
        stateTable = new Dictionary<System.Type, IState>(states.Length);

        anim = GetComponentInChildren<Animator>();

        input = GetComponent<PlayerInput>();

        player = GetComponent<PlayerController>();

        foreach (PlayerState state in states)
        {
            state.Initialize(anim, input, this, player);
            stateTable.Add(state.GetType(), state);
        }
    }

    private void Start()
    {
        OnSwitchState(stateTable[typeof(Player_IdleState)]);
    }
}
