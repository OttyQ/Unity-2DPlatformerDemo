using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject hero; // Перенесено сюда

    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    private KnifeCreate knifeCreate;
    private KnifeThrow knifeThrow;

    void Start()
    {
        // Проверяем, что hero присвоен
        if (hero == null)
        {
            Debug.LogError("Объект Hero не назначен в инспекторе!");
            return; // Прерываем выполнение, если Hero не найден
        }

        // Получаем ссылки на компоненты
        playerMovement = hero.GetComponent<PlayerMovement>();
        playerCombat = hero.GetComponent<PlayerCombat>();
        knifeCreate = hero.GetComponent<KnifeCreate>();
        knifeThrow = hero.GetComponent<KnifeThrow>();

        // Проверяем, что компоненты найдены
        if (playerMovement == null || playerCombat == null || knifeCreate == null || knifeThrow == null)
        {
            Debug.LogError("Один или несколько компонентов Hero не найдены!");
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        if (hero != null)
        {
            // Отключаем все необходимые скрипты
            SetHeroScriptsEnabled(false);
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        if (hero != null)
        {
            // Включаем все необходимые скрипты
            SetHeroScriptsEnabled(true);
        }
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
        Time.timeScale = 1;
    }

    private void SetHeroScriptsEnabled(bool isEnabled)
    {
        if (knifeCreate != null) knifeCreate.enabled = isEnabled;
        if (knifeThrow != null) knifeThrow.enabled = isEnabled;
        if (playerMovement != null) playerMovement.enabled = isEnabled;
        if (playerCombat != null) playerCombat.enabled = isEnabled;
    }
}
