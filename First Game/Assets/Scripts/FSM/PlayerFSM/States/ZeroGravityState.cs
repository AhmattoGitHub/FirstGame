using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravityState : CharacterState
{
    private const float m_boostForce = 500;
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
        if (CanBoostOnX())
            playerStateMachine.RigidBody.AddForce(new Vector2(m_boostForce * playerStateMachine.PlayerInputX * Time.fixedDeltaTime, 0));
        if (CanBoostOnY())
            playerStateMachine.RigidBody.AddForce(new Vector2(0, m_boostForce * playerStateMachine.PlayerInputY * Time.fixedDeltaTime));

        if (playerStateMachine.RigidBody.velocity.magnitude > playerStateMachine.SpeedValue)
        {
            playerStateMachine.RigidBody.velocity = playerStateMachine.RigidBody.velocity.normalized * playerStateMachine.SpeedValue;
        }
    }

    public override void OnUpdate()
    {

    }

    private bool CanBoostOnX()
    {
        if((playerStateMachine.RigidBody.velocity.x >= playerStateMachine.SpeedValue &&
            playerStateMachine.PlayerInputX > 0) || (playerStateMachine.RigidBody.velocity.x <= playerStateMachine.SpeedValue * -1 &&
            playerStateMachine.PlayerInputX < 0))
        {
            return false;
        }

        return true;
    }

    private bool CanBoostOnY()
    {
        if ((playerStateMachine.RigidBody.velocity.y >= playerStateMachine.SpeedValue &&
            playerStateMachine.PlayerInputY > 0) || (playerStateMachine.RigidBody.velocity.y <= playerStateMachine.SpeedValue * -1 &&
            playerStateMachine.PlayerInputY < 0))
        {
            return false;
        }

        return true;
    }
}
