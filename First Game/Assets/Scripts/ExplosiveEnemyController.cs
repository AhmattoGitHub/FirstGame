using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosiveEnemyController : MonoBehaviour
{
    [SerializeField]
    private bool m_isChasingPlayer = false;
    [SerializeField]
    private float m_bombTimer = 0;
    [SerializeField]
    private float m_blowUpTime = 0.3f;
    [SerializeField]
    private float m_movementSpeed = 3f;
    [SerializeField]
    private float m_sightRadius = 8f;
    [SerializeField]
    private float m_explodingRadius = 2f;

    private void Update()
    {
        CheckIfCanChasePlayer();
        CheckIfCanExplode();
    }

    void FixedUpdate()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        if(!m_isChasingPlayer)
        {
            return;
        }
        if(m_bombTimer !=0)
        {
            return;
        }
        float distanceBetweenPlayerAndThis = TestLevelManager.Instance.GetPlayer().transform.position.x - transform.position.x;
        int directionIndex;

        if (distanceBetweenPlayerAndThis < 0)
        {
            directionIndex = -1;
        }
        else
        {
            directionIndex = 1;
        }

        transform.Translate(Vector2.right * directionIndex * m_movementSpeed * Time.fixedDeltaTime);
    }

    private void CheckIfCanExplode()
    {
        if(!m_isChasingPlayer)
        {
            return;
        }

        float distanceBetweenPlayerAndThis = Vector2.Distance(TestLevelManager.Instance.GetPlayer().transform.position, transform.position);
        if (distanceBetweenPlayerAndThis <= m_explodingRadius)
        {
            m_bombTimer += Time.deltaTime;
            if (m_bombTimer >= m_blowUpTime)
            {
                Destroy(gameObject);
            }
            return;
        }
        m_bombTimer = 0;
    }

    private void CheckIfCanChasePlayer()
    {
        float distanceBetweenPlayerAndThis = Vector2.Distance(TestLevelManager.Instance.GetPlayer().transform.position, transform.position);
        if (distanceBetweenPlayerAndThis <= m_sightRadius)
        {
            m_isChasingPlayer = true;
        }
    }
}
