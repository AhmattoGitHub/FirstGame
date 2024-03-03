using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravityState : CharacterState
{
    public override bool CanEnter(IState currentState)
    {
        return playerStateMachine.RigidBody.gravityScale == 0;
    }
     
    public override bool CanExit()
    {
        return playerStateMachine.RigidBody.gravityScale != 0;
    }

    public override void OnEnter()
    {
        Debug.Log("Entering ZeroGravityState!");
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
