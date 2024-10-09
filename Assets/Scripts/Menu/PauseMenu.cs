using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject hero; // ���������� ����

    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    private KnifeCreate knifeCreate;
    private KnifeThrow knifeThrow;

    void Start()
    {
        // ���������, ��� hero ��������
        if (hero == null)
        {
            Debug.LogError("������ Hero �� �������� � ����������!");
            return; // ��������� ����������, ���� Hero �� ������
        }

        // �������� ������ �� ����������
        playerMovement = hero.GetComponent<PlayerMovement>();
        playerCombat = hero.GetComponent<PlayerCombat>();
        knifeCreate = hero.GetComponent<KnifeCreate>();
        knifeThrow = hero.GetComponent<KnifeThrow>();

        // ���������, ��� ���������� �������
        if (playerMovement == null || playerCombat == null || knifeCreate == null || knifeThrow == null)
        {
            Debug.LogError("���� ��� ��������� ����������� Hero �� �������!");
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        if (hero != null)
        {
            // ��������� ��� ����������� �������
            SetHeroScriptsEnabled(false);
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        if (hero != null)
        {
            // �������� ��� ����������� �������
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
