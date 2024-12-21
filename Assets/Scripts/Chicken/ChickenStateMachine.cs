using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenStateMachine : StateMachine
{

    [SerializeField] ChickenState[] states;

    Animator anim;

    ChickenController chicken;

    private void Awake()
    {
        stateTable = new Dictionary<System.Type, IState>(states.Length);

        anim = GetComponentInChildren<Animator>();

        chicken = GetComponent<ChickenController>();

        foreach (ChickenState state in states)
        {
            state.Initialize(anim, chicken, this);
            stateTable.Add(state.GetType(), state);
        }
    }

    private void Start()
    {
        OnSwitchState(stateTable[typeof(Chicken_IdleState)]);
    }
}
