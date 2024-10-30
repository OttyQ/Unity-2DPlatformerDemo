    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class dyingMenu : MonoBehaviour
    {
        [SerializeField] private GameObject DyingMenu;
        public PauseMenu pauseMenu;
        bool isDead = false;
        void Start()
        {
            DyingMenu.SetActive(false);
        }
        public void MenuAwake()
        {
            Debug.Log("Menu start");
            DyingMenu.SetActive(true);
            Time.timeScale = 0f;
            isDead = true;
        }

        public void Revive()
        {
            Debug.Log("Resume start");
            DyingMenu.SetActive(false);
            Time.timeScale = 1f;
            isDead = false;
        }

        public void GoToMM()
        {
            SceneManager.LoadSceneAsync("Main Menu");
            Time.timeScale = 1f;
        }
}
