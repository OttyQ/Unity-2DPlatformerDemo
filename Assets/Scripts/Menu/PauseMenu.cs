using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public bool isPause = false;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        Debug.Log("Pause start");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;

    }

    public void Resume()
    {
        Debug.Log("Resume start");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
        Time.timeScale = 1f;
    }
}
