using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ScoutingState : MeleeEnemyState
{
    private float m_scoutingSpeed = 3f;
    private bool m_isScoutingLeft = false;
    private bool m_isStandingStill = false;

    private float m_timer = 0;
    private const float WAIT_TIME = 2f;
    public override bool CanEnter(IState currentState)
    {
        return true;
    }

    public override bool CanExit()
    {
        return true;
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
        if (!m_isStandingStill)
        {
            if (m_isScoutingLeft)
            {
                m_meleeEnemyStateMachine.Rigidbody.transform.Translate(Vector2.left * m_scoutingSpeed * Time.fixedDeltaTime);
            }
            else
            {
                m_meleeEnemyStateMachine.Rigidbody.transform.Translate(Vector2.right * m_scoutingSpeed * Time.fixedDeltaTime);
            }
        }
    }

    public override void OnUpdate()
    {
        StandStillTimer();
        UpdateScoutingStatus();
    }

    private void StandStillTimer()
    {
        if(!m_isStandingStill)
        {
            return;
        }

        m_timer += Time.deltaTime;
        if(m_timer >= WAIT_TIME)
        {
            m_timer = 0;
            m_isStandingStill = false;
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

    private void UpdateScoutingStatus()
    {
        if (Mathf.Abs(m_meleeEnemyStateMachine.Rigidbody.transform.position.x - m_meleeEnemyStateMachine.StartingPosition.x) >= 5)
        {
            if (m_isScoutingLeft && (m_meleeEnemyStateMachine.Rigidbody.transform.position.x - m_meleeEnemyStateMachine.StartingPosition.x < 0))
            {
                m_isStandingStill = true;
            }
            else if (!m_isScoutingLeft && (m_meleeEnemyStateMachine.Rigidbody.transform.position.x - m_meleeEnemyStateMachine.StartingPosition.x > 0))
            {
                m_isStandingStill = true;
            }
        }
    }
}
