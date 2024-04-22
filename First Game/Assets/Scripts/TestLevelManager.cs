using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestLevelManager : MonoBehaviour
{
    private static TestLevelManager _instance;
    [SerializeField]
    private float m_levelGravityScale = 0;
    [SerializeField]
    private Camera m_mainCamera;
    [SerializeField]
    private GameObject m_player;

    // Property to access the singleton instance
    public static TestLevelManager Instance
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

    public float GetLevelGravityScale()
    {
        return m_levelGravityScale;
    }

    public Camera GetCamera()
    {
        return m_mainCamera;
    }

    public GameObject GetPlayer()
    {
        return m_player;
    }
}
