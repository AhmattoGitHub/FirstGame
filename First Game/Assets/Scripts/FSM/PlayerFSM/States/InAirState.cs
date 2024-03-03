using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAirState : CharacterState
{
    public override bool CanEnter(IState currentState)
    {
        return playerStateMachine.IsInAir == true && playerStateMachine.RigidBody.gravityScale != 0;
    }

    public override bool CanExit()
    {
        return playerStateMachine.IsInAir == false || playerStateMachine.RigidBody.gravityScale == 0;
    }

    public override void OnEnter()
    {
        Debug.Log("Entering InAirState!");
    }

    public override void OnExit()
    {
        Debug.Log("Exiting InAirState!");
    }

    public override void OnFixedUpdate()
    {
        playerStateMachine.RigidBody.transform.Translate(playerStateMachine.SpeedValue * playerStateMachine.PlayerInputX * Time.fixedDeltaTime, 0, 0);
    }

    public override void OnUpdate()
    {

    }
}
