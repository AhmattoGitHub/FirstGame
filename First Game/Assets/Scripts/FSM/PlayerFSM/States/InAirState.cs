using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAirState : CharacterState
{
    public override bool CanEnter(IState currentState)
    {
        return playerStateMachine.IsInAir == true;
    }

    public override bool CanExit()
    {
        return playerStateMachine.IsInAir == false;
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
        playerStateMachine.RigidBody.transform.Translate(playerStateMachine.MaxSpeed * playerStateMachine.PlayerInputX * Time.fixedDeltaTime, 0, 0);
    }

    public override void OnUpdate()
    {

    }
}
