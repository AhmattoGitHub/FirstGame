using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterState
{
    public override bool CanEnter(IState currentState)
    {
        return !playerStateMachine.IsWalking && !playerStateMachine.IsInAir; ;
    }

    public override bool CanExit()
    {
        return playerStateMachine.IsWalking || playerStateMachine.IsInAir;
    }

    public override void OnEnter()
    {
        Debug.Log("Entering Idle State!");
    }

    public override void OnExit()
    {

    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {

    }
}
