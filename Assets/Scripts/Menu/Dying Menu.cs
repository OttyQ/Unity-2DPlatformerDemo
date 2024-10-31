    using System.Collections;
    using System.Collections.Generic;
    using Unity.Properties;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class dyingMenu : MonoBehaviour
    {
        [SerializeField] private GameObject DyingMenu;
        [SerializeField] private Health heroHealth;
        //bool isDead = false;
    void Start(){
            DyingMenu.SetActive(false);
    }
    public void MenuAwake(){
            Debug.Log("Menu start");
            DyingMenu.SetActive(true);
            Time.timeScale = 0f;
            //isDead = true;
        }

        public void Revive()
        {
            Debug.Log("Resume start");
            heroHealth.HandleRevive();
            DyingMenu.SetActive(false);
            Time.timeScale = 1f;
            //isDead = false;
        }

        public void GoToMM()
        {
            SceneManager.LoadSceneAsync("Main Menu");
            Time.timeScale = 1f;
        }

        public void HandleActive()
        {
            DyingMenu.SetActive(true);
            MenuAwake();
        }
}
