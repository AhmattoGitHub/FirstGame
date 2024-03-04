using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private PlayerStateMachine m_playerStateMachine;
    [SerializeField]
    private Vector3 m_offset = new Vector3(0, 0, -20);
    [SerializeField]
    private float m_lerpValue = 0.1f;
    [SerializeField]
    private float m_viewDistance = 10;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(m_playerStateMachine.RigidBody.position.x,m_playerStateMachine.RigidBody.position.y,0) + m_offset;
    }

    private void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(transform.position, m_playerStateMachine.transform.position + m_offset,m_lerpValue) ;
        if (m_playerStateMachine.RigidBody.gravityScale != 0)
            LookUpOrDown();
    }

    private void LookUpOrDown()
    {
        this.transform.position = Vector2.Lerp(transform.position,
            new Vector2(transform.position.x,transform.position.y + (m_playerStateMachine.PlayerInputY * m_viewDistance)), m_lerpValue);
        this.transform.position += m_offset;
    }
}
