using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAirState : CharacterState
{
    private float m_speed;
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
        m_speed = playerStateMachine.SpeedValue * Time.fixedDeltaTime;
    }

    public override void OnExit()
    {

    }

    public override void OnFixedUpdate()
    {
        playerStateMachine.RigidBody.transform.Translate(m_speed* playerStateMachine.PlayerInputX, 0, 0);
    }

    public override void OnUpdate()
    {

    }
}
