using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAcidSpit : MonoBehaviour
{
    [SerializeField]
    private bool m_isDescending = false;
    [SerializeField]
    private int m_launchHeight = 15;
    [SerializeField]
    private float m_launchSpeed = 30;
    [SerializeField]
    private bool m_movedTowardsCursor = false;
    [SerializeField]
    private GameObject m_playerObject;
    [SerializeField]
    private bool m_movedTowardsPoint;

    private float xDistanceBetweenCursorAndSpit;
    // Start is called before the first frame update
    void Start()
    {
        xDistanceBetweenCursorAndSpit = TestPlayerPowersManager.Instance.GetClickPosition().x - this.transform.position.x;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Mathf.Abs(this.transform.position.y - m_playerObject.transform.position.y) >= m_launchHeight)
        {
            m_isDescending = true;
        }
    }

    private void FixedUpdate()
    {
        if (!m_isDescending)
            LaunchToSky();
        else
        {
            MoveTowardsPoint();
            DescendFromSky();
        }
    }

    private void LaunchToSky()
    {
        this.transform.Translate(Vector2.up * m_launchSpeed * Time.fixedDeltaTime);
    }

    private void DescendFromSky()
    {
        this.transform.Translate(Vector2.down * m_launchSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(this.gameObject);
        }
    }

    private void MoveTowardsPoint()
    {
        if(!m_movedTowardsPoint)
        {
            transform.Translate(Vector2.right * xDistanceBetweenCursorAndSpit);
            m_movedTowardsPoint = true;
        }
    }
}
