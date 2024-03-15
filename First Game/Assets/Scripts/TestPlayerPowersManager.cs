using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TestPlayerPowersManager : MonoBehaviour
{
    private static TestPlayerPowersManager _instance;

    [SerializeField]
    private PlayerStateMachine m_playerStateMachine;
    [SerializeField]
    private GameObject m_acidSpitObject;
    [SerializeField]
    private GameObject m_bulletSpitObject;
    [SerializeField]
    private bool m_unlockedAcidSpit = false;
    [SerializeField]
    private bool m_unlockedBulletSpit = false;

    private Vector3 m_clickPosition;

    // Property to access the singleton instance
    public static TestPlayerPowersManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("There is no Instance");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        CheckForInput();
    }

    private void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) { m_clickPosition = Input.mousePosition; SpitAcid(); }
        else if(Input.GetKeyDown(KeyCode.Mouse0)) { m_clickPosition = Input.mousePosition; SpitBullet(); }
    }

    private void SpitAcid()
    {
        if(m_unlockedAcidSpit)
        {
            Debug.Log("Spitting acid!");
            Instantiate(m_acidSpitObject,m_playerStateMachine.RigidBody.transform.position,m_acidSpitObject.gameObject.transform.rotation);
        }
    }

    private void SpitBullet()
    {
        if(m_unlockedBulletSpit)
        {
            Debug.Log("Spitting bullet!");
            Instantiate(m_bulletSpitObject, m_playerStateMachine.RigidBody.transform.position, m_bulletSpitObject.gameObject.transform.rotation);
        }
    }

    public Vector2 GetClickPosition()
    {
        m_clickPosition.z = TestLevelManager.Instance.GetCamera().transform.position.z * -1;
        Vector2 mousePositionWorld = TestLevelManager.Instance.GetCamera().ScreenToWorldPoint(m_clickPosition);
        Debug.Log(mousePositionWorld.x + " " + mousePositionWorld.y);
        return mousePositionWorld;
    }
}
