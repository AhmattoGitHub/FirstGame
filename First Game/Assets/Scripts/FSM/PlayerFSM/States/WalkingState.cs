using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : CharacterState
{
    public override bool CanEnter(IState currentState)
    {
        return playerStateMachine.IsWalking && !playerStateMachine.IsInAir;
    }

    public override bool CanExit()
    {
        return !playerStateMachine.IsWalking || playerStateMachine.IsInAir;
    }

    public override void OnEnter()
    {
        Debug.Log("Entering Moving State!");
    }

    public override void OnExit()
    {

    }

    public override void OnFixedUpdate()
    {
        playerStateMachine.RigidBody.transform.Translate(playerStateMachine.MaxSpeed * playerStateMachine.PlayerInputX * Time.fixedDeltaTime, 0, 0);
    }

    public override void OnUpdate()
    {

    }
}
