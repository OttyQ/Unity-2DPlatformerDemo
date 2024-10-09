using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausecheck : MonoBehaviour
{
    [SerializeField] PauseMenu pauseMenu;
    [SerializeField] GameObject Hero;
    private bool isPaused = false;
    void Update()
    {
        //смена клавиши для паузы
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isPaused)
            {
                pauseMenu.Resume();
                isPaused = false;
            }
            else
            {
                pauseMenu.Pause();
                isPaused = true;
            }

        }
    }
}
