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
    private bool m_unlockedAcidSpit = false;

    private Vector2 m_clickPosition;

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
    }

    private void SpitAcid()
    {
        if(m_unlockedAcidSpit)
        {
            Debug.Log("Spitting acid!");
            Instantiate(m_acidSpitObject,m_playerStateMachine.RigidBody.transform.position,m_acidSpitObject.transform.rotation);
        }
    }

    public Vector2 GetClickPosition()
    {
        return m_clickPosition;
    }
}
