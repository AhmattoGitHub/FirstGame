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
        m_meleeEnemyStateMachine.Rigidbody.transform.position = new Vector3
            (Mathf.Lerp(m_meleeEnemyStateMachine.Rigidbody.transform.position.x
            ,TestLevelManager.Instance.GetPlayer().transform.position.x, Time.fixedDeltaTime),
            m_meleeEnemyStateMachine.Rigidbody.transform.position.y, 
            m_meleeEnemyStateMachine.Rigidbody.transform.position.z);
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
