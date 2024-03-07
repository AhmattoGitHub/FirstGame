using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAudioManager : MonoBehaviour
{
    private static GameAudioManager _instance;

    [SerializeField]
    private AudioSource m_musicAudioSource;
    [SerializeField]
    private AudioSource m_effectsAudioSource;
    [SerializeField]
    private Slider m_musicSlider;
    [SerializeField]
    private Slider m_effectsSlider;

    // Property to access the singleton instance
    public static GameAudioManager Instance
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
            DontDestroyOnLoad(m_musicAudioSource.gameObject);
            DontDestroyOnLoad(m_effectsAudioSource.gameObject);
        }
    }

    private void Start()
    {
        m_musicAudioSource.gameObject.transform.position = Camera.main.gameObject.transform.position;
        m_effectsAudioSource.gameObject.transform.position = Camera.main.gameObject.transform.position;
    }

    public void ChangeMusicVolume()
    {
        m_musicAudioSource.volume = m_musicSlider.value;
    }

    public void ChangeEffectsVolume()
    {
        m_effectsAudioSource.volume = m_effectsSlider.value;
    }
}
