using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : CharacterState
{
    [SerializeField]
    private const int MAX_SPEED = 10;
    [SerializeField]
    private const int ACCELERATION_VALUE = 3;

    public override bool CanEnter(IState currentState)
    {
        return playerStateMachine.PlayerInputX != 0;
    }

    public override bool CanExit()
    {
        return playerStateMachine.RigidBody.velocity.magnitude == 0 && playerStateMachine.PlayerInputX == 0;
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
        playerStateMachine.RigidBody.transform.Translate(MAX_SPEED * playerStateMachine.PlayerInputX * Time.fixedDeltaTime, 0, 0);
    }

    public override void OnUpdate()
    {

    }
}
