using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_mainMenu;
    [SerializeField]
    private GameObject m_optionsMenu;
    [SerializeField]
    private Toggle m_fullscreenToggle;

    private static MainMenuManager _instance;

    // Property to access the singleton instance
    public static MainMenuManager Instance
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
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToOptionsMenu()
    {
        m_mainMenu.SetActive(false);
        m_optionsMenu.SetActive(true);
    }

    public void GoToMainMenu()
    {
        m_mainMenu.SetActive(true);
        m_optionsMenu.SetActive(false);
    }

    public void ToggleFullScreen()
    {
        if(m_fullscreenToggle.isOn)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
