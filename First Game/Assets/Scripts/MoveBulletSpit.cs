using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MoveBulletSpit : MonoBehaviour
{
    [SerializeField]
    private float m_travelSpeed = 10;
    [SerializeField]
    private Vector2 m_direction;

    private void Start()
    {
        m_direction = (TestPlayerPowersManager.Instance.GetClickPosition() - new Vector2(transform.position.x, transform.position.y)).normalized;
    }
    private void FixedUpdate()
    {
        transform.Translate(m_direction * m_travelSpeed * Time.fixedDeltaTime);
    }
}
