    using System.Collections;
    using System.Collections.Generic;
    using Unity.Properties;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class dyingMenu : MonoBehaviour
    {
        //[SerializeField] private GameObject DyingMenu;
        

    private void OnEnable()
    {
        MenuAwake();
    }
    public void MenuAwake(){

            Debug.Log("Menu start");
            gameObject.SetActive(true);
            Time.timeScale = 0f;
            //isDead = true;
        }

        public void Revive()
        {
            Debug.Log("Resume start");
            //heroHealth.HandleRevive();
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            //isDead = false;
        }

        public void GoToMM()
        {
            SceneManager.LoadSceneAsync("Main Menu");
            Time.timeScale = 1f;
        }

        public void HandleActive()
        {
            gameObject.SetActive(true);
            MenuAwake();
        }
}
