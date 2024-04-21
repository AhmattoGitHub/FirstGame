using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ScoutingState : MeleeEnemyState
{
    private float m_scoutingSpeed = 3f;
    private bool m_isScoutingLeft = false;
    public override bool CanEnter(IState currentState)
    {
        return true;
    }

    public override bool CanExit()
    {
        return false;
    }

    public override void OnEnter()
    {
        Debug.Log("Entering Scouting State!");
    }

    public override void OnExit()
    {
        Debug.Log("Exiting Scouting State!");
    }

    public override void OnFixedUpdate()
    {
        if(m_isScoutingLeft)
        {
            m_meleeEnemyStateMachine.Rigidbody.transform.Translate(Vector2.left * m_scoutingSpeed * Time.fixedDeltaTime);
        }
        else
        {
            m_meleeEnemyStateMachine.Rigidbody.transform.Translate(Vector2.right * m_scoutingSpeed * Time.fixedDeltaTime);
        }
    }

    public override void OnUpdate()
    {
        if(Mathf.Abs(m_meleeEnemyStateMachine.Rigidbody.transform.position.x - m_meleeEnemyStateMachine.StartingPosition.x) >= 5)
        {
            if(m_isScoutingLeft)
            {
                m_isScoutingLeft = false;
            }
            else
            {
                m_isScoutingLeft = true;
            }
        }
    }
}
