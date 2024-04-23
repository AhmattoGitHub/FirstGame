using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ChasingState : MeleeEnemyState
{
    private Vector2 m_positionOnEnter;
    private float m_movementSpeed = 6f;
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
        MoveTowardsPlayer();
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    private void MoveTowardsPlayer()
    {
        float distanceBetweenPlayerAndThis = TestLevelManager.Instance.GetPlayer().transform.position.x -
        m_meleeEnemyStateMachine.Rigidbody.transform.position.x;
        int directionIndex;

        if (distanceBetweenPlayerAndThis < 0)
        {
            directionIndex = -1;
        }
        else
        {
            directionIndex = 1;
        }

        m_meleeEnemyStateMachine.Rigidbody.transform.Translate(Vector2.right * directionIndex * m_movementSpeed * Time.fixedDeltaTime);
    }
}
