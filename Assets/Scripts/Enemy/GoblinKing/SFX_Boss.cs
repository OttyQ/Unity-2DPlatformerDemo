using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Boss : MonoBehaviour
{
    [Header("Audio Clip SFX")]
    public AudioClip boss_walk;
    public AudioClip boss_attack;
    public AudioClip boss_special_attack;
    public AudioClip boss_hurt_1;
    public AudioClip boss_hurt_2;
    public AudioClip boss_charge;
    public AudioClip boss_die;
    public AudioClip boss_win;

    [Header("Audio Clip SFX")]
    public AudioClip boss_theme;


    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Boss_walk()
    {
        audioManager.PlaySFX(boss_walk);
    }
    public void Boss_attack()
    {

        audioManager.PlaySFX(boss_attack);
    }
    public void Boss_special_attack()
    {
        audioManager.PlaySFX(boss_special_attack);
    }
    public void Boss_hurt()
    {
        int randomClip = Random.Range(1, 3);

        string audioName = "boss_hurt_" + randomClip.ToString();
        AudioClip clip = (AudioClip)typeof(SFX_Boss).GetField(audioName).GetValue(this);

        audioManager.PlaySFX(clip);

    }

    public void Boss_die()
    {
        audioManager.PlaySFX(boss_die);
    }

    public void Boss_charge()
    {
        audioManager.PlaySFX(boss_charge);
    }
    
    public void Boss_win()
    {
        audioManager.PlaySFX(boss_win);
    }

    public void Boss_theme()
    {
        audioManager.ActivateTheme(boss_theme);
    }

    public void Boss_theme_end()
    {
        audioManager.ActivateTheme(audioManager.background);
    }
}
