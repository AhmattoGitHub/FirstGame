using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : MeleeEnemyState
{
    private Vector2 m_positionOnEnter;
    public override bool CanEnter(IState currentState)
    {
        return m_meleeEnemyStateMachine.ChasingPlayer == true;
    }
    public override bool CanExit()
    {
        return false;
    }
    public override void OnEnter()
    {
        Debug.Log("Entering Chasing State!");
        m_positionOnEnter = m_meleeEnemyStateMachine.Rigidbody.transform.position;
    }
    public override void OnExit()
    {

    }
    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
